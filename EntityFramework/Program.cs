using EntityFramework.Data;
using EntityFramework.Models;

var context = new EFCoreDemoDbContext();

// Step 3: Add three users (only if not already added)
if (!context.Users.Any())
{
    var user1 = new User { Name = "Alice Smith", EmailAddress = "alice@email.com", PhoneNumber = "555-1111" };
    var user2 = new User { Name = "Bob Jones", EmailAddress = "bob@email.com", PhoneNumber = "555-2222" };
    var user3 = new User { Name = "Carol White", EmailAddress = "carol@email.com", PhoneNumber = "555-3333" };

    context.Users.AddRange(user1, user2, user3);
    context.SaveChanges();
}

// Step 4: Add a new post linked to user 1
var existingUser = context.Users.First();

var newPost = new Post
{
    Title = "My First Post",
    Content = "This is the content.",
    BlogId = 1,
    PostTypeId = 1,
    UserId = existingUser.UserId
};

context.Posts.Add(newPost);
context.SaveChanges();

Console.WriteLine("Done! Users and post added.");