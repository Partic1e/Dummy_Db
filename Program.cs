using System.Collections.Generic;

namespace Dummy_Db
{
    class Program
    {
        private const string CsvFolderPath = "..\\..\\..\\..\\Dummy_DB";

        static void Main(string[] args)
        {
            string studentsPath = string.Concat(CsvFolderPath, "\\student.csv");
            string booksPath = string.Concat(CsvFolderPath, "\\book.csv");
            string studentsBookPath = string.Concat(CsvFolderPath, "\\studentsBook.csv");

            List<Student> students;
            List<Book> books;
            List<StudentsBook> studentsBook;

            studentsBook = CsvReader.ReadStudentsBook(studentsBookPath);
            students = CsvReader.ReadStudent(studentsPath);
            books = CsvReader.ReadBook(booksPath);

            WriterTable.WriteTable(studentsBook, books, students);
        }
    }
}
