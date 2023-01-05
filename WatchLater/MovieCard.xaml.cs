using System.Windows.Input;

namespace WatchLater;

public partial class MovieCard : ContentView
{
    public static BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(MovieCard));
    public static BindableProperty IconUrlProperty = BindableProperty.Create(nameof(IconUrl), typeof(string), typeof(MovieCard));
    public static BindableProperty SelectMovieCommandProperty = BindableProperty.Create(nameof(SelectMovieCommand), typeof(ICommand), typeof(MovieCard));

    public static Random Rand = new Random();

    public ICommand SelectMovieCommand
    {
        get => (ICommand)GetValue(MovieCard.SelectMovieCommandProperty);
        private set => SetValue(MovieCard.SelectMovieCommandProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(MovieCard.TitleProperty);
        set => SetValue(MovieCard.TitleProperty, value);
    }

    public string IconUrl
    {
        get => (string)GetValue(MovieCard.IconUrlProperty);
        set => SetValue(MovieCard.IconUrlProperty, value);
    }

    public Color Colour => GetPaletteColor();

    public MovieCard()
    {
        InitializeComponent();
        SelectMovieCommand = new SelectMovieCommand();
    }

    private Color GetPaletteColor()
    {
        return new Color(1, 0, 1);
    }
}