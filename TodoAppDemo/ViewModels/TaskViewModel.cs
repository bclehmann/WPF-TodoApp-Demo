using TodoAppDemo.Models;

namespace TodoAppDemo.ViewModels;

public class TaskViewModel : ViewModelBase
{
    private readonly TaskModel task;

    public TaskViewModel(TaskModel task)
    {
        this.task = task;
    }

    public bool Completed
    {
        get => task.Completed;
        set
        {
            if (task.Completed != value)
            {
                task.Completed = value;
                OnPropertyChanged(nameof(Completed));
            }
        }
    }

    public string Content
    {
        get => task.Content;
        set
        {
            if (task.Content != value)
            {
                task.Content = value;
                OnPropertyChanged(nameof(Content));
            }
        }
    }
}
