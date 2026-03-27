namespace MauiMediaElementBugApp
{
    public partial class MainPage : ContentPage
    {
        private IDispatcherTimer _timer;
        private double _playbackSpeed;

        public MainPage()
        {
            InitializeComponent();
            _playbackSpeed = 1.0;
            MyPlayer.Source = "d:\\dev\\mauimediaelementbugapp\\testmovie.mp4";
        }

        private void MyPlayer_OnLoaded(object sender, EventArgs e)
        {
            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += Timer_Tick;
            _timer.Start();
            MyPlayer.Play();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // note how every time this fires, a movie with sound will briefly stutter while the speed change occurs
            // replace the video with one that excludes an audio track and the speed increase is smooth
            _playbackSpeed += 0.1;
            MyPlayer.Speed = _playbackSpeed;
        }
    }
}
