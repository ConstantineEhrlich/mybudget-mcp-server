using System.ComponentModel;
using ModelContextProtocol.Server;
using MyBudgetClient.BudgetRestClient;

namespace MyBudgetClient.Mcp;

[McpServerToolType]
public class MyBudgetTools
{
    [Description("Get all public budgets"), McpServerTool] public static Task<ICollection<BudgetFile>> GetAllBudgets(IBudgetFileClient budgets, CancellationToken cancellationToken)
            => budgets.BudgetsAllAsync(cancellationToken);
    
    [Description("Get budgets available for editing"), McpServerTool] public static Task<ICollection<BudgetFile>> GetMyBudgets(IBudgetFileClient budgets, CancellationToken cancellationToken)
            => budgets.MyAsync(cancellationToken);

    [Description("Create a new budget"), McpServerTool] public static Task<BudgetFile> CreateBudget(IBudgetFileClient budgets, CancellationToken cancellationToken,
        [Description("New budget object")] BudgetFileAdd body)
            => budgets.NewAsync(body, cancellationToken);

    [Description("Get budget by ID"), McpServerTool] public static Task<BudgetFile> GetBudgetById(IBudgetFileClient budgets, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId)
            => budgets.BudgetsGETAsync(budgetId, cancellationToken);
    
    [Description("Delete budget by ID"), McpServerTool] public static Task DeleteBudget(IBudgetFileClient budgets, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId)
            => budgets.BudgetsDELETEAsync(budgetId, cancellationToken);
    
    [Description("Update budget definition"), McpServerTool] public static Task UpdateBudget(IBudgetFileClient budgets, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("Updated budget definition")] BudgetFileUpdate body)
            => budgets.BudgetsPUTAsync(budgetId, body, cancellationToken);
    
    [Description("Add owner to the budget definition"), McpServerTool] public static Task AddOwner(IBudgetFileClient budgets, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("Owner details")] BudgetOwnerAdd body)
            => budgets.AddOwnerAsync(budgetId, body, cancellationToken);
    
    [Description("Remove owner from the budget definition"), McpServerTool] public static Task RemoveOwner(IBudgetFileClient budgets, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("Owner details")] BudgetOwnerAdd body)
            => budgets.RemoveOwnerAsync(budgetId, body, cancellationToken);
    
    [Description("Add a new category to a budget"), McpServerTool] public static Task<Category> AddCategory(ICategoryClient categories, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("New category object")] CategoryAdd body)
            => categories.AddAsync(budgetId, body, cancellationToken);

    [Description("Get all categories in a budget"), McpServerTool] public static Task<ICollection<Category>> GetAllCategories(ICategoryClient categories, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId)
            => categories.CategoriesAllAsync(budgetId, cancellationToken);

    [Description("Get category by ID"), McpServerTool] public static Task<Category> GetCategoryById(ICategoryClient categories, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("ID of the category")] string catId)
            => categories.CategoriesGETAsync(budgetId, catId, cancellationToken);

    [Description("Update category"), McpServerTool] public static Task<Category> UpdateCategory(ICategoryClient categories, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("ID of the category")] string catId,
        [Description("Updated category object")] CategoryUpdate body)
            => categories.CategoriesPUTAsync(budgetId, catId, body, cancellationToken);

    [Description("Delete category by ID"), McpServerTool] public static Task DeleteCategory(ICategoryClient categories, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("ID of the category")] string catId)
            => categories.CategoriesDELETEAsync(budgetId, catId, cancellationToken);

    [Description("Toggle category status (active/inactive)"), McpServerTool] public static Task ChangeCategoryStatus(ICategoryClient categories, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("ID of the category")] string catId)
            => categories.ChangeStatusAsync(budgetId, catId, cancellationToken);
    
    [Description("Add a new transaction to a budget"), McpServerTool] public static Task<Transaction> AddTransaction(ITransactionClient transactions, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("New transaction object")] TransactionAdd body)
            => transactions.Add2Async(budgetId, body, cancellationToken);

    [Description("Get all transactions in a budget"), McpServerTool] public static Task<ICollection<Transaction>> GetAllTransactions(ITransactionClient transactions, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId)
            => transactions.TransactionsAllAsync(budgetId, cancellationToken);

    [Description("Get transaction by ID"), McpServerTool] public static Task<Transaction> GetTransactionById(ITransactionClient transactions, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("ID of the transaction")] string transId)
            => transactions.TransactionsGETAsync(budgetId, transId, cancellationToken);

    [Description("Update transaction"), McpServerTool] public static Task<Transaction> UpdateTransaction(ITransactionClient transactions, CancellationToken cancellationToken,
        [Description("ID of the budget")] string budgetId,
        [Description("ID of the transaction")] string transId,
        [Description("Updated transaction object")] TransactionUpdate body)
            => transactions.TransactionsPUTAsync(budgetId, transId, body, cancellationToken);
}