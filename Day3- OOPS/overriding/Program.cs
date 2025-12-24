namespace oopssession{
    public class Father
    {
       public virtual string intereston()
       {
        return "Playing cricket";
       }
      
    }
     public class Son:Father
     {
        public override string intereston()
        {
            return "Playing football";
        }
     }
}