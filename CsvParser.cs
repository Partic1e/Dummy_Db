using System;
using System.Collections.Generic;
using System.IO;

namespace Dummy_Db
{
    public static class CsvParser
    {
        public static List<Student> ParseStudent(List<Student> students)
        {
            int count = default;
            foreach (string line in File.ReadLines("student.csv"))
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }
                string[] splitted = line.Split(";");
                if (splitted.Length == 2)
                {
                    Student student = new();
                    if (int.TryParse(splitted[0], out int value))
                        student.Id = value;
                    else
                        throw new Exception($"error: Id в файле student.csv  в {count} строке должен быть целым числом");
                    student.Name = splitted[1];
                    students.Add(student);
                }
                else if (splitted.Length != 2)
                    throw new Exception($"error: Количество данных в {count} строке файла student.csv должно быть равно 2");
                count++;
            }
            return students;
        }

        public static List<Book> ParseBook(List<Book> books)
        {
            int count = default;
            foreach (string line in File.ReadLines("book.csv"))
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }
                string[] splitted = line.Split(";");
                if (splitted.Length == 6)
                {
                    Book book = new();
                    if (int.TryParse(splitted[0], out int value))
                        book.Id = value;
                    else
                        throw new Exception($"error: Id в файле book.csv  в {count} строке должен быть целым числом");
                    book.Name = splitted[1];
                    book.AuthorName = splitted[2];
                    if (int.TryParse(splitted[3], out value))
                        book.YearOfPublication = value;
                    else
                        throw new Exception($"Год публикации в файле book.csv  в {count} строке должен быть целым числом");
                    if (int.TryParse(splitted[4], out value))
                        book.Case = value;
                    else
                        throw new Exception($"error: номер шкафа в файле book.csv  в {count} строке должен быть целым числом");
                    if (int.TryParse(splitted[5], out value))
                        book.Shelf = value;
                    else
                        throw new Exception($"error: номер полки в файле book.csv  в {count} строке должен быть целым числом");
                    books.Add(book);
                }
                else if (splitted.Length != 6)
                    throw new Exception($"error: Количество данных в {count} строке файла book.csv должно быть равно 6");
                count++;
            }
            return books;
        }

        public static List<StudentsBook> ParseStudentsBook(List<StudentsBook> studentsBook)
        {
            int count = default;
            foreach (string line in File.ReadLines("studentsBook.csv"))
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }
                string[] splitted = line.Split(";");
                if (splitted.Length == 4)
                {
                    StudentsBook studentBook = new();
                    if (int.TryParse(splitted[0], out int value))
                        studentBook.BookId = value;
                    else
                        throw new Exception($"error: Id книги в файле studentsBook.csv в  {count} строке должен быть целым числом");
                    if (int.TryParse(splitted[1], out value))
                        studentBook.StudentId = value;
                    else
                        throw new Exception($"error: Id человека в файле studentsBook.csv в  {count} строке должен быть целым числом");
                    studentBook.DateOfGetting = DateTime.Parse(splitted[2]);
                    studentBook.DateOfReturning = DateTime.Parse(splitted[3]);
                    if (studentBook.DateOfGetting > studentBook.DateOfReturning)
                        throw new Exception($"error: в файле studentsBook.csv в  {count} строке дата взятия книги не может быть позже даты возвращения");
                    studentsBook.Add(studentBook);
                    count++;
                }
            }
            return studentsBook;
        }
    }
}