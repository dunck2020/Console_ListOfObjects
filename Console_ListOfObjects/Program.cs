using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_ListOfObjects
{

    // **************************************************
    //
    // Title: List of Objects
    // Description: Simple console program to allow
    // user to enter book objects
    // Application Type: Console
    // Authors:         Dunckel, John 
    // Constributors:   Haroutunian, Colin
    //                  Hosler, Robert
    // Dated Created: 1/11/2021
    // Last Modified: 1/18/2021
    // 
    // **************************************************


    class Program
    {

        #region CONSTANT

        const string DATAPATH = @"C:\Users\John\Desktop\CIT195 Application Dev\QuickCodes\Console_ListOfObjects\Console_ListOfObjects\BookList.txt";

        #endregion

        static void Main()
        {
            ConsoleProcess();
        }

        /// <summary>
        /// Main methods contained here
        /// </summary>
        static void ConsoleProcess()
        {
            List<Books> bookList = new List<Books>();
            AddObjects(bookList);
            DisplayObjects(bookList);
            SaveBookListToTextFile(bookList);
            Console.WriteLine("\tBook list succesfully saved.");
            Console.WriteLine();
            Console.ReadKey();

        }

        /// <summary>
        /// Prompt user to add book information to create object
        /// </summary>
        /// <param name="bookList"></param>
        static void AddObjects(List<Books> bookList)
        {
            bool addMoreBooks;
            AddObjectsTextHeader("\tWelcome to the book list program");
            Console.WriteLine();
            AddObjectsTextHeader("\tPlease enter your first book.");
            do
            {
                Books userObject = new Books();
                GetAllBookItemsFromUserForBookObject(userObject);
                bookList.Add(userObject);
                AddObjectsTextHeader("\tWould you like to provide additional books?\n");
                addMoreBooks = DualConfirmation();
                Console.WriteLine();
                

            } while (addMoreBooks == true);

        }

        /// <summary>
        /// assign book entries to object
        /// </summary>
        /// <param name="userObject"></param>
        static void GetAllBookItemsFromUserForBookObject(Books userObject)
        {
            userObject.Title = GetBookTitleAndAuthor("\tEnter a title: ");
            userObject.Author = GetBookTitleAndAuthor("\tPlease enter the author: ");
            userObject.Pages = GetBookNumberOfPagesAndReleaseYear("\tPlease enter the number of pages: ");
            userObject.ReleaseYear = GetBookNumberOfPagesAndReleaseYear("\tPlease add in the release year here: ");
            GetBookGenre(userObject);
        }

        /// <summary>
        /// Assign book genre from enum in class chosen by user
        /// </summary>
        /// <param name="userObject"></param>
        static void GetBookGenre(Books userObject)
        {
            bool genreAnswer;
            do
            {
                Console.Clear();
                DisplayListOfGenres();
                AddGenreHeader();
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine($"\tIs {Books.Genre.HistoricalFiction} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.HistoricalFiction;
                        break;
                    case "2":
                        Console.WriteLine($"\tIs {Books.Genre.Fantasy} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.Fantasy;
                        break;
                    case "3":
                        Console.WriteLine($"\tIs {Books.Genre.Biographical} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.Biographical;
                        break;
                    case "4":
                        Console.WriteLine($"\tIs {Books.Genre.Classical} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.Classical;
                        break;
                    case "5":
                        Console.WriteLine($"\tIs {Books.Genre.Politics} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.Politics;
                        break;
                    case "6":
                        Console.WriteLine($"\tIs {Books.Genre.Religious} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.Religious;
                        break;
                    case "7":
                        Console.WriteLine($"\tIs {Books.Genre.Horror} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.Horror;
                        break;
                    case "8":
                        Console.WriteLine($"\tIs {Books.Genre.ScienceFiction} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.ScienceFiction;
                        break;
                    case "9":
                        Console.WriteLine($"\tIs {Books.Genre.Romance} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.Romance;
                        break;
                    case "10":
                        Console.WriteLine($"\tIs {Books.Genre.Nonfiction} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.Nonfiction;
                        break;
                    case "11":
                        Console.WriteLine($"\tIs {Books.Genre.Historical} correct?");
                        genreAnswer = DualConfirmation();
                        if (genreAnswer)
                            userObject.GenreType = Books.Genre.Historical;
                        break;
                    default:
                        Console.WriteLine("\tPlease re-enter a choice from the menu, using only numbers 1-11.");
                        genreAnswer = false;
                        break;
                }
            } while (!genreAnswer);
        }

        /// <summary>
        /// promt user for number enties for pages and release year
        /// </summary>
        /// <param name="messageForUser"></param>
        /// <returns></returns>
        static int GetBookNumberOfPagesAndReleaseYear(string messageForUser)
        {
            bool correctEntry = false;
            int entryNumber;
            do
            {
                AddObjectsTextHeader(messageForUser);
                if (!int.TryParse(Console.ReadLine(), out entryNumber))
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a number.");
                }
                else
                {
                    Console.WriteLine($"\tIs {entryNumber} correct?");
                    correctEntry = DualConfirmation();
                }

            } while (!correctEntry);
            return entryNumber;
        }

        /// <summary>
        /// prompt user for strings book title and author name
        /// </summary>
        /// <param name="messageForUser"></param>
        /// <returns></returns>
        static string GetBookTitleAndAuthor(string messageForUser)
        {
            bool correctEntry;
            string bookInfoEntry;
            do
            {
                AddObjectsTextHeader(messageForUser);
                bookInfoEntry = Console.ReadLine();
                Console.WriteLine($"\tIs {bookInfoEntry} correct?");
                correctEntry = DualConfirmation();
            } while (!correctEntry);

            return bookInfoEntry;
        }

        /// <summary>
        /// display a list of selectable genres to user
        /// </summary>
        static void DisplayListOfGenres()
        {
            Console.WriteLine("\tGenre Types:");
            Console.WriteLine();
            int i = 0;
            foreach (string genre in Enum.GetNames(typeof(Books.Genre)))
            {
                i++;
                Console.WriteLine($"\t{i}) {genre}");
            }
        }

        /// <summary>
        /// method to add header to display
        /// </summary>
        static void AddGenreHeader()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\tPlease select the book's genre: ");
        }

        /// <summary>
        /// display objects to user in list
        /// </summary>
        /// <param name="bookList"></param>
        static void DisplayObjects(List<Books> bookList)
        {
            foreach (var book in bookList)
            {
                Console.WriteLine("\t*********************************");
                Console.WriteLine();
                Console.WriteLine($"\tAuthor: \t{book.Author}");
                Console.WriteLine($"\tTitle: \t\t{book.Title}");
                Console.WriteLine($"\tPages: \t\t{book.Pages}");
                Console.WriteLine($"\tRelease Year: \t{book.ReleaseYear}");
                Console.WriteLine($"\tGenre: \t\t{book.GenreType}");
                Console.WriteLine();    
            }
            DisplayInformationOnEntriesForUser(bookList);
        }

        /// <summary>
        /// display averages on entries for user
        /// </summary>
        /// <param name="bookList"></param>
        static void DisplayInformationOnEntriesForUser(List<Books> bookList)
        {
            Console.WriteLine();
            Console.WriteLine("\t*********************************");
            Console.WriteLine();
            int totalBooks = bookList.Count();
            Console.WriteLine($"\tYou have entered a total of {totalBooks} book(s).");

            int releaseYear = 0;
            foreach (var book in bookList)
            {
                releaseYear += book.ReleaseYear;
            }
            releaseYear /= totalBooks;
            Console.WriteLine($"\tThe average release year is {releaseYear}.");

            int pageCount = 0;
            foreach (var book in bookList)
            {
                pageCount += book.Pages;
            }
            pageCount /= totalBooks;
            Console.WriteLine($"\tThe average number of pages is {pageCount}.");

            Console.WriteLine();
            Console.WriteLine("\tPress any Key to Continue");
            Console.ReadLine();
        }

        /// <summary>
        /// header display
        /// </summary>
        /// <param name="userQuestion"></param>
        static void AddObjectsTextHeader(string userQuestion)
        {
            Console.WriteLine();
            Console.Write(userQuestion);
        }

        /// <summary>
        /// Colin's code from Capstone project- updated by John Dunckel 01-15-21
        /// </summary>
        /// <returns></returns>
        static bool DualConfirmation()
        {
            Console.WriteLine("\tPress ENTER for yes or ESC for no.");
            ConsoleKeyInfo keyEntry;
            bool userRes = false;
            bool validKey = false;
            do
            {
                keyEntry = Console.ReadKey(intercept: true);
                switch (keyEntry.Key)
                {
                    case ConsoleKey.Enter:
                        userRes = true;
                        validKey = true;
                        break;
                    case ConsoleKey.Escape:
                        userRes = false;
                        validKey = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tERROR: incorrect '{0}' key entered.", keyEntry.Key);
                        Console.WriteLine("\tRetry your key submission.");
                        break;
                }
            } while (validKey != true);
            Console.Clear();
            return userRes;
        }

        static void SaveBookListToTextFile(List<Books> booklist)
        {
            foreach (var book in booklist)
            {
                string fileString = 
                    book.Title + ", " +
                    book.Author + ", " +
                    book.Pages.ToString() + ", " +
                    book.ReleaseYear.ToString() + ", " +
                    book.GenreType.ToString() + "\n";

                try
                {
                    File.AppendAllText(DATAPATH, fileString);

                }
                catch (Exception)
                {
                    Console.WriteLine("\tSorry can not write to file.");
                }
            }


        }

    }
}
