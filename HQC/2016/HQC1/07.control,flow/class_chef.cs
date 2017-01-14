public class Chef
{
    
    public void Cook()
    {
        
        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);

        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);

        Bowl bowl = GetBowl();
        bowl.Add(carrot);
        bowl.Add(potato);
    }
    private Bowl GetBowl()
    {   
        //... 
    }
    private Potato GetPotato()
    {
        //...
    }
    private Carrot GetCarrot()
    {
        //...
    }
    private void Cut(Vegetable potato)
    {
        //...
    }
}