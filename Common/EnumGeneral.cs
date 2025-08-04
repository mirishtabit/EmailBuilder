namespace EmailBuilder.Common
{

    public enum Position
    {
        Left,
        Center,
        Right
    }

    public enum Direction
    {
        Parent, // Inherits from parent element
        Ltr,
        Rtl 
    }

    public enum ClientElementType
    {
        Section, 
        Text,     
        Image,
        Layout,   // Represents the main layout of the email

    }

  


}