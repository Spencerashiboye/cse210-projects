using System;

public class Fraction
{
    private int _top;
    private int _buttom;

    public Fraction()
    {
        _top = 1;
        _buttom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _buttom = 1;
    }

    public Fraction(int top, int buttom)
    {
      _top = top;
      _buttom = buttom;  
    }

    public string Getfractionstring()
    {
        string text = $"{_top}/{_buttom}";
        return text;
    }

    public double GetDecimalvalue()
    {
        return(double)_top / (double)_buttom;
    }
}