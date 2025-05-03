using System.Collections.ObjectModel;
using TodoAppDemo.Models;

namespace TodoAppDemo.ViewModels;

public class TaskListViewModel : ViewModelBase
{
    private readonly ObservableCollection<TaskViewModel> tasks;
    private TaskViewModel? selectedItem;

    public TaskListViewModel()
    {
        tasks = new ObservableCollection<TaskViewModel>([
            new TaskViewModel(new TaskModel { Content = "Eggs" }),
            new TaskViewModel(new TaskModel { Content = "Milk" }),
            new TaskViewModel(new TaskModel { Content = "Coffee" }),
        ]);
    }

    public ObservableCollection<TaskViewModel> Tasks => tasks;
    public TaskViewModel? SelectedItem
    {
        get => selectedItem;
        set
        {
            if (selectedItem != value)
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
    }

    public void AddTask(string content)
    {
        var task = new TaskModel() { Content = content };
        var taskViewModel = new TaskViewModel(task);
        tasks.Add(taskViewModel);

        SelectedItem = taskViewModel;
    }

    public void RemoveTask(TaskViewModel taskViewModel)
    {
        tasks.Remove(taskViewModel);
    }
}
