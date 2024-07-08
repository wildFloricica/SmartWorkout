
namespace SmartWorkout.Components.Pages
{

    public partial class Counter
    {
        private static int currentCount = 0;

        bool visible = true;

        Task OnClicked()
        {
            visible = false;

            return Task.CompletedTask;
        }
        private void IncrementCount()
        {
            currentCount++;
        }
    }
}
