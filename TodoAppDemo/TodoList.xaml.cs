using System.Windows.Controls;
using System.Windows.Input;
using TodoAppDemo.ViewModels;

namespace TodoAppDemo;

public partial class TodoList : UserControl
{
    private TaskListViewModel TypedDataContext => DataContext as TaskListViewModel ?? throw new ArgumentNullException(nameof(DataContext));
    public TodoList()
    {
        InitializeComponent();
        DataContext = new ViewModels.TaskListViewModel();
    }
    
    public static RoutedCommand AddEmptyTaskCommand = new RoutedCommand();

    public void AddEmptyTaskExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        TypedDataContext.AddTask(string.Empty);
    }

    private void TextBoxKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            e.Handled = true;
            TypedDataContext.AddTask(string.Empty);
        }
    }
}