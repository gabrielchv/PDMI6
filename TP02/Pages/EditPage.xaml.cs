using TP02.Models;
using TP02.Repository;

namespace TP02.Pages;

public partial class EditPage : ContentPage
{
	private TaskModel currentTask;
    private readonly TaskRepository taskRepository;
    public EditPage(TaskModel task)
	{
		InitializeComponent();

		currentTask = task;
		BindingContext = task;

        taskRepository = new TaskRepository();

    }

    private async void onEdit(object sender, EventArgs e)
    {
        taskRepository.Update(currentTask.Id, currentTask);
        await Navigation.PopModalAsync();
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }
}