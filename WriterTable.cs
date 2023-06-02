using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace Dummy_Db
{
    static class WriterTable
    {
        private static int GetAuthorLength(List<Book> books, int maxAuthor = 0)
        {
            foreach (var book in books)
                maxAuthor = Math.Max(maxAuthor, book.AuthorName!.Length);
    
            return maxAuthor;
        }

        private static int GetBookLength(List<Book> books, int maxBookName = 0)
        {
            foreach (var book in books)
                maxBookName = Math.Max(maxBookName, book.Name!.Length);
            
            return maxBookName;
        }

        private static int GetStudentLength(List<Student> students, int maxStudentName = 0)
        {
            foreach (var student in students)
                maxStudentName = Math.Max(maxStudentName, student.Name!.Length);

            return maxStudentName;
        }

        private static int GetDateLength(List<StudentsBook> studentsBook, int dateLength = 0)
        {
            foreach (var studentBook in studentsBook)
                dateLength = Math.Max(dateLength, studentBook.Name!.Length);

            return dateLength;
        }

        public static void WriteTable(List<StudentsBook> studentsBook, List<Book> books, List<Student> students)
        {
            int maxAuthor = GetAuthorLength(books);
            int maxBookName = GetBookLength(books);
            int maxReader = GetStudentLength(students);
            int maxDateLength = GetDateLength(studentsBook);

            int lengthOfLine = maxBookName + maxAuthor + maxReader + maxDateLength + 5;

            Console.WriteLine(new string('-', lengthOfLine));
            Console.WriteLine($"|{"Имя читателя".PadRight(maxReader)}|{"Название".PadRight(maxBookName)}|{"Автор".PadRight(maxAuthor)}|{"Взял".PadRight(maxDateLength)}|");
            Console.WriteLine(new string('-', lengthOfLine));

            foreach (var item in studentsBook)
            {
                Student? student = students.Find(s => s.Id == item.StudentId);
                Book? book = books.Find(b => b.Id == item.BookId);

                string dateOfGetting = item.DateOfGetting.ToString("dd.MM.yyyy");

                Console.Write("|" + student!.Name!.PadRight(maxReader) + "|");
                Console.Write(book!.Name!.PadRight(maxBookName) + "|");
                Console.Write(book.AuthorName!.PadRight(maxAuthor) + "|");
                Console.Write(dateOfGetting.PadRight(maxDateLength) + "|");
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', lengthOfLine));
        }
    }
}
