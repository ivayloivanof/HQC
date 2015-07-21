namespace CohesionAndCoupling
{
    using System;

    public class File
    {
        public static string GetFileExtension(string fileName)
        {
            var indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                throw new FileMissingExtension(string.Format("File {0} missing extension.", fileName));
            }

            var extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                throw new FileMissingExtension(string.Format("File {0} missing extension.", fileName));
            }

            var extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
