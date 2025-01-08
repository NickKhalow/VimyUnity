namespace VimyUnity.Editor
{
    public interface IWindowsFocus
    {
        void FocusOn(FocusType type);

        enum FocusType
        {
            Next,
            Previous,
            Up,
            Down,
            Right,
            Left
        }
    }
}