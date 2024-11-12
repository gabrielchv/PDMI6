using System.Threading.Tasks;
using TP02.Models;
using TP02.Repository;

namespace TP02.Pages;

public partial class DetailsPage : ContentPage
{
    private TaskModel currenteTask;
    private readonly TaskRepository taskRepository;

    public DetailsPage(TaskModel task)
	{
		InitializeComponent();

        currenteTask = task;
        BindingContext = task;

        taskRepository = new TaskRepository();
    }

    private async void OnEditarClick(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditPage(currenteTask));
    }

    private async void OnExcluirClick(object sender, EventArgs e)
    {
        bool remove = await DisplayAlert("Excluir item",
                                        "Deseja realmente remover o item:\n" + currenteTask.Title,
                                        "Sim",
                                        "N�o");

        if (currenteTask != null && remove)
        {
            taskRepository.Remove(currenteTask.Id);
        }

        await Navigation.PopAsync();
    }

    protected override void OnAppearing()
    {
        currenteTask = taskRepository.Get(currenteTask.Id);
        BindingContext = currenteTask;
        base.OnAppearing();
    }
}