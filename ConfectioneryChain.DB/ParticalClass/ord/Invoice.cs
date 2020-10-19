using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class Invoice : General
    {
        public override string ToString()
        {
            return $"[{OrderID}]";
        }
        public override General CreateNew()
        {
            var general = new Invoice();
            OrderID = -1;
            Address = null;
            MarkBuyerSignature = false;
            ClaimText = null;
            ReturnMARK = false;
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Invoice general)
            {
                Address = general.Address;
                MarkBuyerSignature = general.MarkBuyerSignature;
                ClaimText = general.ClaimText;
                ReturnMARK = general.ReturnMARK;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is Invoice general)
            {
                Fill(general);
                OrderID = general.OrderID;
            }


        }
    }
}
