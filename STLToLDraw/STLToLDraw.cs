using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STLToLDraw
{
	public partial class STLToLDraw : Form
	{
		private OpenFileDialog _ofd;

		public STLToLDraw()
		{
			InitializeComponent();
		}

		private void OpenButtonOnClick(object sender, EventArgs e)
		{
			_ofd = new OpenFileDialog { Filter = "Stereolithography Files|*.stl" };
			if (_ofd.ShowDialog() == DialogResult.OK)
			{
				/*
				using (BinaryReader br = new BinaryReader(_ofd.OpenFile()))
				{
					byte[] header = br.ReadBytes(5);

					if (Encoding.ASCII.GetString(header) == "solid")
					{
						_infoLabel.Text = "ASCII STL files not supported.";
						_ofd = null;
						return;
					}
					else
					{
						_infoLabel.Text = "";
					}
				}
				*/
				_convertButton.Enabled = true;
				_infoLabel.Text = _ofd.FileName;
			}
			else
			{
				_ofd = null;
				_convertButton.Enabled = false;
			}
		}

		private async void ConvertButtonOnClick(object sender, EventArgs e)
		{
			_convertButton.Enabled = false;
			if (_ofd != null)
			{
				SaveFileDialog sfd = new SaveFileDialog { Filter = "LDraw Data File|*.dat", FileName = "Part.dat" };
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					await Task.Run(new Action(() =>
					{
						Invoke((MethodInvoker) delegate { _progressBar.Value = 0; });

						using (Stream output = sfd.OpenFile())
						using (BinaryReader br = new BinaryReader(_ofd.OpenFile()))
						{
							byte[] header = br.ReadBytes(80);
							uint n = br.ReadUInt32();

							Invoke((MethodInvoker) delegate { _progressBar.Maximum = (int) n; });

							HashSet<Tuple<Vector3, Vector3, Triangle>> edges = new HashSet<Tuple<Vector3, Vector3, Triangle>>();

							for (int i = 0; i < n; i++)
							{
								if (i % 500 == 0)
									Invoke((MethodInvoker) delegate { _progressBar.Value = i; }); 

								// normal
								Vector3 normal = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());

								// triangle
								Vector3 a = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle()) * (double) _scaleBox.Value;
								Vector3 b = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle()) * (double) _scaleBox.Value;
								Vector3 c = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle()) * (double) _scaleBox.Value;

								// attrs
								br.ReadUInt16();
								Triangle t = new Triangle(a, b, c, normal);

								// assume colour 16
								string tri = string.Format("3 16 {0:F} {1:F} {2:F} {3:F} {4:F} {5:F} {6:F} {7:F} {8:F}\n",
									t.A.X, t.A.Y, t.A.Z,
									t.B.X, t.B.Y, t.B.Z,
									t.C.X, t.C.Y, t.C.Z);
								output.Write(Encoding.ASCII.GetBytes(tri), 0, tri.Length);

								var curedges = t.Edges;
								foreach (var edge in curedges)
								{
									// use oct-tree for efficiency... later
									Tuple<Vector3, Vector3, Triangle> match = null;
									foreach (var j in edges)
									{
										const double epsilon = 0.000001;
										if ((j.Item1 - edge.Item1).LenSq < epsilon && (j.Item2 - edge.Item2).LenSq < epsilon)
										{
											match = j;
											break;
										}
										else if ((j.Item1 - edge.Item2).LenSq < epsilon && (j.Item2 - edge.Item1).LenSq < epsilon)
										{
											match = j;
											break;
										}
									}

									if (match != null)
									{
										double dot = match.Item3.Normal.Dot(edge.Item3.Normal);

										if (dot < 0.9999)
										{
											if (dot > 0.20)
											{
												// draw optional line
												Vector3 c1 = edge.Item3.Centre, c2 = match.Item3.Centre;
												string line = string.Format("5 24 {0:F} {1:F} {2:F} {3:F} {4:F} {5:F} {6:F} {7:F} {8:F} {9:F} {10:F} {11:F}\n",
												edge.Item1.X, edge.Item1.Y, edge.Item1.Z,
												edge.Item2.X, edge.Item2.Y, edge.Item2.Z,
												c1.X, c1.Y, c1.Z,
												c2.X, c2.Y, c2.Z);
												output.Write(Encoding.ASCII.GetBytes(line), 0, line.Length);
											}
											else
											{
												// permanent line
												string line = string.Format("2 24 {0:F} {1:F} {2:F} {3:F} {4:F} {5:F}\n",
													edge.Item1.X, edge.Item1.Y, edge.Item1.Z,
													edge.Item2.X, edge.Item2.Y, edge.Item2.Z);
												output.Write(Encoding.ASCII.GetBytes(line), 0, line.Length);
											}
										}

										edges.Remove(match);
									}
								}

								foreach (var j in curedges)
								{
									edges.Add(j);
								}
							}

							// unpaired edges
							/*
							foreach (var j in edges)
							{
								string line = string.Format("2 24 {0:F} {1:F} {2:F} {3:F} {4:F} {5:F}\n",
									j.Item1.X, j.Item1.Y, j.Item1.Z,
									j.Item2.X, j.Item2.Y, j.Item2.Z);
								output.Write(Encoding.ASCII.GetBytes(line), 0, line.Length);
							}
							*/
						}
					}));
					_progressBar.Value = 0;
				}
			}
			_convertButton.Enabled = true;
		}

		private struct Vector3
		{
			public double X;
			public double Y;
			public double Z;

			public Vector3(double x, double y, double z)
			{
				X = x;
				Y = y;
				Z = z;
			}

			public double Len
			{
				get { return Math.Sqrt(X * X + Y * Y + Z * Z); }
			}

			public double LenSq
			{
				get { return X * X + Y * Y + Z * Z; }
			}

			public Vector3 Norm
			{
				get { double len = Len; return new Vector3(X / len, Y / len, Z / len); }
			}

			public double Dot(Vector3 other)
			{
				return X * other.X + Y * other.Y + Z * other.Z;
			}

			public Vector3 Cross(Vector3 other)
			{
				return new Vector3(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.Z);
			}

			public static Vector3 operator -(Vector3 a, Vector3 b)
			{
				return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
			}

			public static Vector3 operator +(Vector3 a, Vector3 b)
			{
				return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
			}

			public static Vector3 operator *(Vector3 a, double b)
			{
				return new Vector3(a.X * b, a.Y * b, a.Z * b);
			}

			public static Vector3 operator /(Vector3 a, double b)
			{
				return new Vector3(a.X / b, a.Y / b, a.Z / b);
			}
		}

		private struct Triangle
		{
			public Vector3 A;
			public Vector3 B;
			public Vector3 C;
			public Vector3 Normal;

			public Triangle(Vector3 a, Vector3 b, Vector3 c, Vector3 normal)
			{
				Normal = normal.Norm;

				if ((b - a).Cross(c - a).Norm.Dot(Normal) < 0)
				{
					// wind in opposite direction
					A = a;
					B = c;
					C = b;
				}
				else
				{
					A = a;
					B = b;
					C = c;
				}
			}

			public List<Tuple<Vector3, Vector3, Triangle>> Edges
			{
				get
				{
					List<Tuple<Vector3, Vector3, Triangle>> r = new List<Tuple<Vector3, Vector3, Triangle>>();
					r.Add(Tuple.Create(A, B, this));
					r.Add(Tuple.Create(A, C, this));
					r.Add(Tuple.Create(B, C, this));
					return r;
				}
			}

			public Vector3 Centre
			{
				get { return (A + B + C) / 3; }
			}
		}
	}
}
