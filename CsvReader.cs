using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dummy_Db
{
    static class CsvReader
    {
        public static List<Student> ReadStudent(string path)
        {
            int expectedCount = 2;
            List<Student> students = new List<Student>();
            string[] lines = File.ReadLines(path).ToArray();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split(";");
                CheckInequality(cells.Length, path, expectedCount);
                Student student = new()
                {
                    Id = ValueTryParse(i, cells[0], path),
                    Name = cells[1]
                };
                students.Add(student);
            }

            return students;
        }

        public static List<Book> ReadBook(string path)
        {
            int expectedCount = 6;
            List<Book> books = new();
            string[] lines = File.ReadLines(path).ToArray();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split(";");
                CheckInequality(cells.Length, path, expectedCount);
                Book book = new()
                {
                    Id = ValueTryParse(i, cells[0], path),
                    Name = cells[1],
                    AuthorName = cells[2],
                    YearOfPublication = ValueTryParse(i, cells[3], path),
                    Case = ValueTryParse(i, cells[4], path),
                    Shelf = ValueTryParse(i, cells[5], path)
                };
                books.Add(book);
            }

            return books;
        }
        public static List<StudentsBook> ReadStudentsBook(string path)
        {
            int expectedCount = 4;
            List<StudentsBook> studentsBook = new();
            string[] lines = File.ReadLines(path).ToArray();
            
            for (int i = 1; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split(";");
                CheckInequality(cells.Length, path, expectedCount);
                StudentsBook studentBook = new()
                {
                    BookId = ValueTryParse(i, cells[0], path),
                    StudentId = ValueTryParse(i, cells[1], path),
                    DateOfGetting = DateTime.Parse(cells[2]),
                    DateOfReturning = DateTime.Parse(cells[3])
                };
                studentsBook.Add(studentBook);
            }

            return studentsBook;
        }

        private static int ValueTryParse(int i, string data, string path)
        {
            if (!int.TryParse(data, out int value))
                throw new Exception($"Данные в файле {path}  в {i} строке должен быть целым числом");
            return value;
        }

        private static void CheckInequality(int actualCount, string path, int expectedCount)
        {
            if (actualCount != expectedCount)
                throw new Exception($"error: Количество данных в каждой строке файла {path} должно быть равно {expectedCount}");
        }
    }
}