using System;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace Petri
{
    [Serializable, XmlRoot("Arrow", Namespace = "", IsNullable = false)]
    public class ArrowRenderer
    {
        #region Properties

        private float width = 15;
        /// <summary>
        /// Gets or sets width (in pixels) of the full base of the arrowhead
        /// </summary>
        /// <value>The width.</value>
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        private float theta = 0.5f;
        /// <summary>
        /// Gets or sets angle (in radians) at the arrow tip between the two sides of the arrowhead
        /// </summary>
        /// <value>The theta.</value>
        public float Theta
        {
            get { return theta; }
            set { theta = value; }
        }

        public void SetThetaInDegrees(float degrees)
        {
            if (degrees <= 0) degrees = 1;
            if (degrees >= 180) degrees = 179;
            theta = (float)Math.PI / 180 * degrees;
        }

        private bool fillArrowHead = true;
        /// <summary>
        /// Gets or sets flag indicating whether or not the arrowhead should be filled
        /// </summary>
        /// <value><c>true</c> if arrow head should be filled; otherwise, <c>false</c>.</value>
        public bool FillArrowHead
        {
            get { return fillArrowHead; }
            set { fillArrowHead = value; }
        }

        private int numberOfBezierCurveNodes = 100;
        /// <summary>
        /// Gets or sets the number of nodes used to calculate bezier curve.
        /// </summary>
        /// <value>The number of bezier curve nodes.</value>
        public int NumberOfBezierCurveNodes
        {
            get { return numberOfBezierCurveNodes; }
            set
            {
                if (value > 4) numberOfBezierCurveNodes = value;
            }
        }

        #endregion

        #region Constructors

        public ArrowRenderer() { }

        public ArrowRenderer(float width)
        {
            this.width = width;
        }

        public ArrowRenderer(float width, float theta)
        {
            this.width = width;
            this.theta = theta;
        }

        public ArrowRenderer(float width, float theta, bool fillArrowHead)
        {
            this.width = width;
            this.theta = theta;
            this.fillArrowHead = fillArrowHead;
        }

        public ArrowRenderer(float width, float theta, bool fillArrowHead, int numberOfBezierCurveNodes)
        {
            this.width = width;
            this.theta = theta;
            this.fillArrowHead = fillArrowHead;
            this.numberOfBezierCurveNodes = numberOfBezierCurveNodes;
        }

        #endregion

        #region DrawArrow

        public void DrawArrow(Graphics g, Pen pen, Brush brush, float x1, float y1, float x2, float y2)
        {
            DrawArrow(g, pen, brush, new PointF(x1, y1), new PointF(x2, y2));
        }

        /// <summary>
        /// Renders the arrow on given graphics using desired paramethers.
        /// </summary>
        /// <param name="g">The grahpics object.</param>
        /// <param name="pen">The pen of the stroke.</param>
        /// <param name="brush">The brush of the fill.</param>
        /// <param name="p1">Initial point.</param>
        /// <param name="p2">Terminal point.</param>
        public void DrawArrow(Graphics g, Pen pen, Brush brush, PointF p1, PointF p2)
        {
            PointF[] aptArrowHead = new PointF[3];

            // set first node to terminal point            
            aptArrowHead[0] = p2;

            Vector vecLine = new Vector(p2.X - p1.X, p2.Y - p1.Y);// build the line vector
            Vector vecLeft = new Vector(-vecLine[1], vecLine[0]);// build the arrow base vector - normal to the line

            // setup remaining arrow head points
            float lineLength = vecLine.Length;
            float th = Width / (2.0f * lineLength);
            float ta = Width / (2.0f * ((float)Math.Tan(Theta / 2.0f)) * lineLength);

            // find the base of the arrow
            PointF pBase = new PointF(aptArrowHead[0].X + -ta * vecLine[0], aptArrowHead[0].Y + -ta * vecLine[1]); //base of the arrow

            // build the points on the sides of the arrow
            aptArrowHead[1] = new PointF(pBase.X + th * vecLeft[0], pBase.Y + th * vecLeft[1]);
            aptArrowHead[2] = new PointF(pBase.X + -th * vecLeft[0], pBase.Y + -th * vecLeft[1]);

            g.DrawLine(pen, p1, pBase); //master line

            if (FillArrowHead) g.FillPolygon(brush, aptArrowHead); //fill arrow head if desired

            g.DrawPolygon(pen, aptArrowHead); //draw outline
        }

        #endregion

        #region DrawArrowOnCurve

        public void DrawArrowOnCurve(Graphics g, Pen pen, Brush brush, float[] controlPoints)
        {
            if (controlPoints.Length != 8)
                throw new ArgumentException("controlPoints has to be valid float array 8 elements in length");
            DrawArrowOnCurve(g, pen, brush, controlPoints[0], controlPoints[1], controlPoints[2], controlPoints[3],
                                            controlPoints[4], controlPoints[5], controlPoints[6], controlPoints[7]);
        }

        /// <summary>
        /// Renders the arrow on given graphics using desired paramethers.
        /// </summary>
        /// <param name="g">The grahpics object.</param>
        /// <param name="pen">The pen of the stroke.</param>
        /// <param name="brush">The brush of the fill.</param>
        /// <param name="p1">Initial point.</param>
        /// <param name="p2">Terminal point.</param>
        /// <param name="p1c">First control point.</param>
        /// <param name="p2c">Second control point.</param>
        public void DrawArrowOnCurve(Graphics g, Pen pen, Brush brush, PointF p1, PointF p2, PointF p1c, PointF p2c)
        {
            DrawArrowOnCurve(g, pen, brush, p1.X, p1.Y, p2.X, p2.Y, p1c.X, p1c.Y, p2c.X, p2c.Y);
        }

        public void DrawArrowOnCurve(Graphics g, Pen pen, Brush brush, float p1X, float p1Y, float p2X, float p2Y, float p1cX, float p1cY, float p2cX, float p2cY)
        {
            if (numberOfBezierCurveNodes < 4) numberOfBezierCurveNodes = 4;
            PointF[] bezierLine = GetBezierCurveNodes(p1X, p1Y, p2X, p2Y, p1cX, p1cY, p2cX, p2cY, numberOfBezierCurveNodes);

            float arrowHeadHeight = width / (2.0f * ((float)Math.Tan(theta / 2.0f)));
            float distDelta = arrowHeadHeight;
            int lineTerminalNode = bezierLine.Length - 2;
            for (int i = bezierLine.Length - 2; i >= 1; i--)
            {
                float currDist = GetDistance(bezierLine[i].X, bezierLine[i].Y, p2X, p2Y);
                float tempDelta = Math.Abs(arrowHeadHeight - currDist);

                if (tempDelta > distDelta) break;
                distDelta = tempDelta;
                lineTerminalNode = i;
            }

            PointF pBase = bezierLine[lineTerminalNode]; //set arrow base node
            arrowHeadHeight = GetDistance(pBase.X, pBase.Y, p2X, p2Y);

            PointF[] aptArrowHead = new PointF[3];
            aptArrowHead[0] = new PointF(p2X, p2Y); // set first node to terminal point

            //Vector vecLine = new Vector(p2.X - pBase.X, p2.Y - pBase.Y); // build the arrow height vector
            //Vector vecLeft = new Vector(pBase.Y - p2.Y, p2.X - pBase.X); // build the arrow base vector - normal to the line

            float th = width / (2.0f * arrowHeadHeight);//coeficient used for remaining arrow head points setup
            // build the points on the remaining sides of the arrow
            aptArrowHead[1] = new PointF(pBase.X + th * (pBase.Y - p2Y), pBase.Y + th * (p2X - pBase.X));
            aptArrowHead[2] = new PointF(pBase.X + th * (p2Y - pBase.Y), pBase.Y + th * (pBase.X - p2X));

            g.DrawCurve(pen, bezierLine, 0, lineTerminalNode); //master line
            if (FillArrowHead) g.FillPolygon(brush, aptArrowHead); //fill arrow head if desired
            g.DrawPolygon(pen, aptArrowHead); //draw outline

            #region Debug - nodes
            /* //visually check position of all nodes
            using (Pen ppp = new Pen(Color.FromArgb(150, Color.Red)))
                for (int i = 0; i < bezierLine.Length; i++)
                {
                    g.DrawEllipse(ppp, bezierLine[i].X - 2, bezierLine[i].Y - 2, 4, 4);
                }*/
            #endregion

            #region Alternate - draw path

            /*using(GraphicsPath gp = new GraphicsPath())
            {
                //gp.FillMode = FillMode.Alternate;
                gp.AddCurve(bezierLine, 0, lineTerminalNode, 1); //master line
                gp.AddPolygon(aptArrowHead); //outline

                if (FillArrowHead) 
                    g.FillPath(brush, gp); //fill arrow head if desired
                g.DrawPath(pen, gp);
            }*/

            #endregion
        }

        private PointF[] GetBezierCurveNodes(PointF p1, PointF p2, PointF p1c, PointF p2c, int numberOfNodes)
        {
            return GetBezierCurveNodes(p1.X, p1.Y, p2.X, p2.Y, p1c.X, p1c.Y, p2c.X, p2c.Y, numberOfNodes);
        }

        protected PointF[] GetBezierCurveNodes(float p1X, float p1Y, float p2X, float p2Y, float p1cX, float p1cY, float p2cX, float p2cY, int numberOfNodes)
        {
            PointF[] apt = new PointF[numberOfNodes];

            float dt = 1f / (apt.Length - 1);
            float t = -dt;
            for (int i = 0; i < apt.Length; i++)
            {
                t += dt;
                float tt = t * t;
                float ttt = tt * t;
                float tt1 = (1 - t) * (1 - t);
                float ttt1 = tt1 * (1 - t);

                float x = ttt1 * p1X +
                          3 * t * tt1 * p1cX +
                          3 * tt * (1 - t) * p2cX +
                          ttt * p2X;

                float y = ttt1 * p1Y +
                          3 * t * tt1 * p1cY +
                          3 * tt * (1 - t) * p2cY +
                          ttt * p2Y;

                apt[i] = new PointF(x, y);
            }
            return apt;
        }

        /// <summary>
        /// Calculate Euclieden distance between two points.
        /// </summary>
        /// <param name="x1">The first point x coordinate.</param>
        /// <param name="y1">The first point y coordinate</param>
        /// <param name="x2">The second point x coordinate</param>
        /// <param name="y2">The second point y coordinate</param>
        /// <returns></returns>
        protected float GetDistance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        #endregion

        #region DrawArrows

        public void DrawArrows(Graphics g, Pen pen, Brush brush, PointF[] apf)
        {
            DrawArrows(g, pen, brush, apf, 0, 0);
        }

        public void DrawArrows(Graphics g, Pen pen, Brush brush, PointF[] apf, float startOffset, float endOffset)
        {
            PointF fromP = apf[0], toP;
            for (int i = 0; i < apf.Length - 1; i++)
            {
                toP = apf[i + 1];
                Vector vecLine = new Vector(toP.X - fromP.X, toP.Y - fromP.Y);
                Vector vecStart = vecLine - (vecLine.Length - startOffset);
                PointF nFromP = new PointF(fromP.X + vecStart.X, fromP.Y + vecStart.Y);
                Vector vecEnd = vecLine - endOffset;
                PointF nToP = new PointF(fromP.X + vecEnd.X, fromP.Y + vecEnd.Y);
                DrawArrow(g, pen, brush, nFromP, nToP);
                fromP = toP;
            }
        }

        /// <summary>
        /// Draws arrows between consecutive points.
        /// </summary>
        /// <param name="g">The graphics object.</param>
        /// <param name="pen">The pen of the stroke.</param>
        /// <param name="brush">The brush of the fill.</param>
        /// <param name="apf">Array of points at which arrow polygon will be spanned.</param>
        /// <param name="startOffsets">The start offsets.</param>
        /// <param name="endOffsets">The end offsets.</param>
        public void DrawArrows(Graphics g, Pen pen, Brush brush, PointF[] apf, float[] startOffsets, float[] endOffsets)
        {
            if (apf.Length < 2) throw new ArgumentException("PointF[] apf has to be at least 2 in length");
            if (apf.Length != startOffsets.Length || apf.Length != endOffsets.Length ||
                endOffsets.Length != startOffsets.Length)
                throw new ArgumentException("apf, startOffsets and endOffsets have to be arrays of equal length");

            PointF[] newApf = new PointF[apf.Length + 1];
            Array.Copy(apf, newApf, apf.Length);
            newApf[newApf.Length - 1] = newApf[0];

            PointF fromP = newApf[0], toP;
            for (int i = 0; i < newApf.Length - 1; i++)
            {
                toP = newApf[i + 1];
                Vector vecLine = new Vector(toP.X - fromP.X, toP.Y - fromP.Y);
                Vector vecStart = vecLine - (vecLine.Length - startOffsets[i]);
                PointF nFromP = new PointF(fromP.X + vecStart.X, fromP.Y + vecStart.Y);
                Vector vecEnd = vecLine - endOffsets[i];
                PointF nToP = new PointF(fromP.X + vecEnd.X, fromP.Y + vecEnd.Y);
                DrawArrow(g, pen, brush, nFromP, nToP);
                fromP = toP;
            }
        }

        #endregion
    }

    /// <summary>
    /// Represents generalised vector
    /// </summary>
    [Serializable, DebuggerDisplay("{ToString()}, Len = {Length}")]
    [XmlRoot("Vector", Namespace = "", IsNullable = false)]
    public class Vector : ICloneable
    {
        #region Private members and properties

        private float m_X;

        /// <summary>
        /// X Coordination of vector
        /// </summary>
        public float X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        private float m_Y;

        /// <summary>
        /// Y Coordination of vector
        /// </summary>
        public float Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        private float m_Z;

        /// <summary>
        /// Z Coordination of vector
        /// </summary>
        public float Z
        {
            get { return m_Z; }
            set { m_Z = value; }
        }

        /// <summary>
        /// Gets the length of vector.
        /// </summary>
        /// <value>The length.</value>
        public float Length
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z); }
        }

        /// <summary>
        /// Gets the angle (in radiands) between x-axis and vector's projection to OXY plane.
        /// </summary>
        /// <value>The angle.</value>
        public float Alpha
        {
            get { return (float)Math.Atan2(Y, X); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor. Initiate vector at the (0,0,0) location
        /// </summary>
        public Vector()
        {
        }

        /// <summary>
        /// Initiate 2D vector with given parameters
        /// </summary>
        /// <param name="inX">X coordination of vector</param>
        /// <param name="inY">Y coordination of vector</param>
        public Vector(float inX, float inY)
        {
            m_X = inX;
            m_Y = inY;
            m_Z = 0;
        }

        /// <summary>
        /// Initiate vector with given parameters
        /// </summary>
        /// <param name="inX">X coordination of vector</param>
        /// <param name="inY">Y coordination of vector</param>
        /// <param name="inZ">Z coordination of vector</param>
        public Vector(float inX, float inY, float inZ)
        {
            m_X = inX;
            m_Y = inY;
            m_Z = inZ;
        }

        /// <summary>
        /// Initiate vector with given parameters
        /// </summary>
        /// <param name="coordination">Vector's coordinations as an array</param>
        public Vector(float[] coordination)
        {
            m_X = coordination[0];
            m_Y = coordination[1];
            m_Z = coordination[2];
        }

        /// <summary>
        /// Initiate vector with same values as given Vector
        /// </summary>
        /// <param name="vector">Vector to copy coordinations</param>
        public Vector(Vector vector)
        {
            m_X = vector.X;
            m_Y = vector.Y;
            m_Z = vector.Z;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add 2 vectors and create a new one.
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>New vector that is the sum of the 2 vectors</returns>
        public static Vector Add(Vector vector1, Vector vector2)
        {
            if (((Object)vector1 == null) || ((Object)vector2 == null))
                return null;
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
        }

        /// <summary>
        /// Substract 2 vectors and create a new one.
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>New vector that is the difference of the 2 vectors</returns>
        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            if (((Object)vector1 == null) || ((Object)vector2 == null))
                return null;
            return new Vector(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
        }

        /// <summary>
        /// Return a new vector with negative values.
        /// </summary>
        /// <param name="vector">Original vector</param>
        /// <returns>New vector that is the inversion of the original vector</returns>
        public static Vector Negate(Vector vector)
        {
            if ((Object)vector == null) return null;
            return new Vector(-vector.X, -vector.Y, -vector.Z);
        }

        /// <summary>
        /// Multiply a vector with a scalar
        /// </summary>
        /// <param name="vector">Vector to be multiplied</param>
        /// <param name="val">Scalar to multiply vector</param>
        /// <returns>New vector that is the multiplication of the vector with the scalar</returns>
        public static Vector Multiply(Vector vector, float val)
        {
            if ((Object)vector == null)
                return null;
            return new Vector(vector.X * val, vector.Y * val, vector.Z * val);
        }

        /// <summary>
        /// Calculates dot product of n vectors.
        /// </summary>
        /// <param name="vectors">vectors array.</param>
        /// <returns></returns>
        public static float DotProduct(params Vector[] vectors)
        {
            if (vectors.Length < 2)
                throw new ArgumentException("dot product can be calculated from at least two vectors");
            float dx = vectors[0].X, dy = vectors[0].Y, dz = vectors[0].Z;

            for (int i = 1; i < vectors.Length; i++)
            {
                dx *= vectors[0].X;
                dy *= vectors[0].Y;
                dz *= vectors[0].Z;
            }

            return (dx + dy + dz);
        }

        public static Vector Contract(Vector vect, float dLength)
        {
            float length = vect.Length;
            return new Vector(vect.X - (vect.X * dLength / length),
                              vect.Y - (vect.Y * dLength / length),
                              vect.Z - (vect.Z * dLength / length));
        }

        public static Vector Expand(Vector vect, float dLength)
        {
            return Contract(vect, -1 * dLength);
        }

        public void Translate(float dx, float dy, float dz)
        {
            X += dx;
            Y += dy;
            Z += dz;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Check equality of two vectors
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>True - if he 2 vectors are equal.
        /// False - otherwise</returns>
        public static bool operator ==(Vector vector1, Vector vector2)
        {
            if (((Object)vector1 == null) || ((Object)vector2 == null)) return false;
            return ((vector1.X.Equals(vector2.X))
                    && (vector1.Y.Equals(vector2.Y))
                    && (vector1.Z.Equals(vector2.Z)));
        }

        /// <summary>
        /// Check inequality of two vectors
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>True - if he 2 vectors are not equal.
        /// False - otherwise</returns>
        public static bool operator !=(Vector vector1, Vector vector2)
        {
            if (((Object)vector1 == null) || ((Object)vector2 == null)) return false;
            return (!(vector1 == vector2));
        }

        /// <summary>
        /// Calculate the sum of 2 vectors.
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>New vector that is the sum of the 2 vectors</returns>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            if (((Object)vector1 == null) || ((Object)vector2 == null)) return null;
            return Add(vector1, vector2);
        }

        /// <summary>
        /// Calculate the substraction of 2 vectors
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>New vector that is the difference of the 2 vectors</returns>
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            if (((Object)vector1 == null) || ((Object)vector2 == null))
                return null;
            return Subtract(vector1, vector2);
        }

        public static Vector operator -(Vector vector1, float dLength)
        {
            if ((Object)vector1 == null) return null;
            return Contract(vector1, dLength);
        }

        public static Vector operator +(Vector vector1, float dLength)
        {
            if ((Object)vector1 == null) return null;
            return Expand(vector1, dLength);
        }

        /// <summary>
        /// Calculate the negative (inverted) vector
        /// </summary>
        /// <param name="vector">Original vector</param>
        /// <returns>New vector that is the invertion of the original vector</returns>
        public static Vector operator -(Vector vector)
        {
            if ((Object)vector == null) return null;
            return Negate(vector);
        }

        /// <summary>
        /// Calculate the multiplication of a vector with a scalar
        /// </summary>
        /// <param name="vector">Vector to be multiplied</param>
        /// <param name="val">Scalar to multiply vector</param>
        /// <returns>New vector that is the multiplication of the vector and the scalar</returns>
        public static Vector operator *(Vector vector, float val)
        {
            if ((Object)vector == null) return null;
            return Multiply(vector, val);
        }

        /// <summary>
        /// Calculate the multiplication of a vector with a scalar
        /// </summary>
        /// <param name="val">Scalar to multiply vector</param>
        /// <param name="vector">Vector to be multiplied</param>
        /// <returns>New vector that is the multiplication of the vector and the scalar</returns>
        public static Vector operator *(float val, Vector vector)
        {
            if ((Object)vector == null) return null;
            return Multiply(vector, val);
        }

        public float this[byte index]
        {
            get
            {
                if (index < 0 || index > 2) throw new ArgumentException("index has to be integer from interval [0, 2]");
                switch (index)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        return 0;
                }
            }
            set
            {
                if (index < 0 || index > 2) throw new ArgumentException("index has to be integer from interval [0, 2]");
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    case 2:
                        Z = value;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Constants

        /// <summary>
        /// Standard (0,0,0) vector
        /// </summary>
        public static Vector Zero
        {
            get { return new Vector(0.0f, 0.0f, 0.0f); }
        }

        /// <summary>
        /// Standard (1,0,0) vector
        /// </summary>
        public static Vector XAxis
        {
            get { return new Vector(1.0f, 0.0f, 0.0f); }
        }

        /// <summary>
        /// Standard (0,1,0) vector
        /// </summary>
        public static Vector YAxis
        {
            get { return new Vector(0.0f, 1.0f, 0.0f); }
        }

        /// <summary>
        /// Standard (0,0,1) vector
        /// </summary>
        public static Vector ZAxis
        {
            get { return new Vector(0.0f, 0.0f, 1.0f); }
        }

        #endregion

        #region Overides

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is Vector && (Vector)obj == this);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2})", m_X, m_Y, m_Z);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override int GetHashCode()
        {
            return m_X.GetHashCode() ^ m_Y.GetHashCode() ^ m_Z.GetHashCode();
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            return new Vector(this);
        }

        #endregion
    }
}