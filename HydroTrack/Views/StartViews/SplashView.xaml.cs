namespace HydroTrack.Views;

public partial class SplashView : ContentPage
{
    private bool animationRunning = false;

    public SplashView()
    {
        InitializeComponent();
        SizeChanged += OnSizeChanged;
    }

    private async void OnSizeChanged(object sender, EventArgs e)
    {
        if (!animationRunning && Width > 0 && TrainImage.Width > 0)
        {
            animationRunning = true;
            SizeChanged -= OnSizeChanged;

            await AnimateTrainLoop();
        }
    }

    private async Task AnimateTrainLoop()
    {
        double screenWidth = this.Width;
        double trainWidth = TrainImage.Width;
        double targetX = -trainWidth - 300;

        string[] trainImages = { "traina.png", "trainc.png", "traind.png", "traine.png" };
        Random random = new Random();

        TrainImage.TranslationX = screenWidth;

        while (true)
        {
            string selectedImage = trainImages[random.Next(trainImages.Length)];
            TrainImage.Source = ImageSource.FromFile(selectedImage);

            await TrainImage.TranslateTo(targetX, 0, 2000, Easing.Linear);

            TrainImage.TranslationX = screenWidth;
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var rnd = new Random();
        await Task.Delay(rnd.Next(2000, 4000));

        await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
    }
}
