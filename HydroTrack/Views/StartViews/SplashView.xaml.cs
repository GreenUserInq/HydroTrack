namespace HydroTrack.Views;

public partial class SplashView : ContentPage
{
	public SplashView()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        AnimateTrain();

        // Подождать немного
        var rnd = new Random();
        await Task.Delay(rnd.Next(2000, 4000));
        // ? Переход через Shell
        await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
    }

    private void AnimateTrain()
    {
        this.SizeChanged += async (s, e) =>
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
        };
    }

}