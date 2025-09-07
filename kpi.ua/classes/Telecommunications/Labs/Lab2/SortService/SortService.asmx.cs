using System;
using System.ComponentModel;
using System.Web.Services;

namespace SortService
{
    [WebService(Namespace = "http://localhost/SortService.asmx/", Description = "Podolsky Sergey KV-64")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(true)]
    [System.Web.Script.Services.ScriptService]
    public class SortService : WebService
    {
        /// <summary>
        /// Sort matrix of byte.
        /// </summary>
        /// <param name="matrix">
        /// We use jagged array because WebService does not support multidimensional.
        /// Ref required because array is passed by value in WebService.
        /// </param>
        [WebMethod]
        public void SortMatrix(ref byte[][] matrix)
        {
            // Get total count of elements in jagged array
            int size = 0;
            foreach (byte[] line in matrix)
                size += line.Length;
            // Create vector with the same lenghth
            byte[] vector = new byte[size];
            // Copy matrix to vector
            for (int i = 0, k = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[i].Length; j++, k++)
                    vector[k] = matrix[i][j];
            // Sort vector
            Array.Sort(vector);
            // Copy vector to matrix
            for (int i = 0, k = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[i].Length; j++, k++)
                    matrix[i][j] = vector[k];
        }
    }
}
