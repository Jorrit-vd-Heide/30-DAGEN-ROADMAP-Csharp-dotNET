using Microsoft.EntityFrameworkCore;
using Day15_WebApi.Services;
using Day15_WebApi.Database;
using Day15_WebApi.Models;

namespace BookServiceTest
{
    public class BookServiceTest
    {
        private BookService GetServiceWithData()
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new BookContext(options);

            context.Books.Add(new Book { Id = 1, Title = "Clean Code" });
            context.Books.Add(new Book { Id = 2, Title = "Pragmatic Programmer" });
            context.SaveChanges();

            return new BookService(context);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsTwoBooks()
        {
            // Arrange: Initialiseer de service met de in-memory database die twee boeken bevat.
            var service = GetServiceWithData();

            // Act: Roep de methode aan die we willen testen (haal alle boeken op).
            var result = await service.GetAllAsync();

            // Assert: Controleer of het resultaat exact 2 items bevat, zoals verwacht.
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task AddAsync_AddsBookToDatabase()
        {
            // Arrange: 
            // 1. Initialiseer de service met de in-memory database (bevat al 2 boeken).
            var service = GetServiceWithData();

            // 2. Bereid een nieuw Book object voor om toe te voegen.
            var newBook = new Book
            {
                Title = "Test",
                Author = "Me",
                Year = 2024
            };

            // Act: 
            // Roep de methode aan die het nieuwe boek toevoegt aan de database.
            await service.AddAsync(newBook);

            // Assert:
            // 1. Haal alle boeken opnieuw op om de nieuwe telling te controleren.
            var allBooks = await service.GetAllAsync();

            // 2. Controleer of het totale aantal boeken nu 3 is (2 initieel + 1 toegevoegd).
            Assert.Equal(3, allBooks.Count);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesBookTitleCorrectly()
        {
            // Arrange
            var service = GetServiceWithData();
            int bookIdToUpdate = 1;
            string originalTitle = "Clean Code";
            string newTitle = "The Clean Coder: A Code of Conduct for Professional Programmers";

            // 1. Controleer de initiële staat
            var bookBeforeUpdate = await service.GetAsync(bookIdToUpdate);
            Assert.Equal(originalTitle, bookBeforeUpdate.Title);

            // Maak een nieuw Book object met *hetzelfde ID* maar de *nieuwe titel*
            var updatedBookDto = new Book
            {
                Id = bookIdToUpdate,
                Title = newTitle
                // Eventuele andere properties die u bijwerkt
            };

            // Act
            // Roep de UpdateAsync methode aan die uw service gebruikt (accepteert één Book object)
            await service.UpdateAsync(updatedBookDto);

            // Assert
            // 2. Haal het boek opnieuw op uit de database via de service
            var bookAfterUpdate = await service.GetAsync(bookIdToUpdate);

            // 3. Verifieer dat de titel nu de nieuwe waarde heeft
            Assert.NotNull(bookAfterUpdate);
            Assert.Equal(newTitle, bookAfterUpdate.Title);

            // 4. Verifieer dat het ID niet is veranderd
            Assert.Equal(bookIdToUpdate, bookAfterUpdate.Id);
        }


        [Fact]
        public async Task DeleteAsync_RemovesBook()
        {
            // Arrange: Initialiseer de service met de in-memory database.
            // Boek met ID 1 bestaat nu (toegevoegd in GetServiceWithData()).
            var service = GetServiceWithData();

            // Act: 
            // Roep de DeleteAsync methode aan om het boek met ID 1 te verwijderen.
            await service.DeleteAsync(1);

            // Assert:
            // 1. Probeer het boek met ID 1 opnieuw op te halen.
            var result = await service.GetAsync(1);

            // 2. Controleer of het resultaat 'null' is, wat bevestigt dat het boek succesvol is verwijderd.
            Assert.Null(result);
        }
    }
}
