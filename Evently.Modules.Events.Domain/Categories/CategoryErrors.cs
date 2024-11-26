using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Categories;

public static class CategoryErrors
{
    public static Error NotFound(Guid categoryId) =>
        Error.NotFound("Categories.NotFound",
            $"The category with id: {categoryId} does not exist.");
    public static readonly Error AlreadyArchived = Error.Problem("Categories.AlreadyArchived",
        "The category is already archived.");
}
