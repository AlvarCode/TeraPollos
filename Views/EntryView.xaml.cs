namespace TeraPollos.Views;

/// <summary>
/// Un componente personalizado de entrada de texto.
/// </summary>
public partial class EntryView : ContentView
{
	/// <summary>
	/// Establece el recurso de imagen como icono de la entrada de texto.
	/// </summary>
	public ImageSource IconSource
	{
		set => icon.Source = value;
	}

	/// <summary>
	/// Obtiene o establece un valor que indica si la entrada debe mostrar o no un icono.
	/// </summary>
	public bool HasIcon
	{
		get => icon.IsVisible;
		set => icon.IsVisible = value;
	}

	/// <summary>
	/// Obtiene o establece el texto que se muestra cuando la entrada está vacía.
	/// </summary>
	public string PlaceholderText
	{
		get => entry.Placeholder;
		set => entry.Placeholder = value;
	}

	/// <summary>
	/// Obtiene o establece el texto escrito en la entrada.
	/// </summary>
	public string Text
	{
		get => entry.Text;
		set => entry.Text = value;
	}

    /// <summary>
    /// Representa el método a ejecutar cada vez que cambie el texto de la entrada. El método debe tener 
	/// la siguiente firma:
	/// <example>
	/// <code>
	/// void HandlerMethodName(TextEventArgs e) { ... }
	/// </code>
	/// </example>
    /// </summary>
    public Action<TextChangedEventArgs>? OnTextChanged { get; set; }

	public EntryView()
	{
		InitializeComponent();
		entry.TextChanged += (object? sender, TextChangedEventArgs e) => OnTextChanged?.Invoke(e);
	}

	void ToggleFocus(object? sender, FocusEventArgs e)
	{
		container.Stroke = entry.IsFocused
									? (Color)Application.Current.Resources["AccentColor"]
									: Brush.Transparent;
	}

	void Container_Tapped(object? sender, TappedEventArgs e)
	{
		SetFocus();
	}

    /// <summary>
	/// Intenta establecer el foco en la entrada de texto.
	/// </summary>
	/// <returns>
	///		<c>true</c> Si se logra dar el enfoque a la entrada, de lo contrario <c>false</c>.
	/// </returns>
    public bool SetFocus()
	{
		return entry.IsFocused ? true : entry.Focus();
	}
}