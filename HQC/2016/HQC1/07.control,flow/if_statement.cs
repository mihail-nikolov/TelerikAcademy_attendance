 //Task 2. Refactor the following if statements
Potato potato = null;
//... 
if (potato != null)
{
    if (potato.HasBeenPeeled && !potato.IsRotten)
    {
        Cook(potato);
    }                    
}
//..and
bool inRange = MIN_X <= x && x <= MAX_X && MIN_Y <= y && y <= MAX_Y;
if (inRange && shouldVisitCell)
{
   VisitCell();
}
