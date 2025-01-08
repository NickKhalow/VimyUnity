namespace VimyUnity.Editor
{
    public interface IWindowsFocus
    {
        void FocusOn(FocusType type);

        void CloseCurrent();

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