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
    
    public readonly static RoutedCommand AddEmptyTaskCommand = new RoutedCommand();
    public readonly static RoutedCommand DeleteTaskCommand = new RoutedCommand();

    public void AddEmptyTaskExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        TypedDataContext.AddTask(string.Empty);
    }

    public void DeleteTaskExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        if (e.Parameter is not TaskViewModel taskViewModel)
        {
            throw new ArgumentNullException(nameof(taskViewModel));
        }

        TypedDataContext.RemoveTask(taskViewModel);
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