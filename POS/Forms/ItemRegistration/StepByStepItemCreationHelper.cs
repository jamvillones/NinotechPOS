using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.ItemRegistration
{

    public static class StepByStepItemCreationHelper
    {
        public static Item SetBasicInfo(this Item item)
        {
            var form = new BasicInformation_Form(item);

            if (form.ShowDialog() != DialogResult.OK)
            {
                throw new OperationCanceledException("Basic Information Cancelled");
            }

            return item;
        }

        public static Item AskIfSerialRequired(this Item item)
        {
            if (!item.IsFinite)
                return item;

            var form = new RequireSerialNumber_Form(item);

            if (form.ShowDialog() != DialogResult.OK)
                throw new OperationCanceledException("Serial Number Cancelled");

            return item;
        }

        public static Item SetCosts(this Item item)
        {
            if (!item.IsFinite)
                return item;

            var form = new ItemCost_Form(item);

            if (form.ShowDialog() != DialogResult.OK)
                throw new OperationCanceledException("Cost Cancelled");

            return item;
        }

        public static Item SetImage(this Item item)
        {
            var form = new Item_Image_From(item);

            if (form.ShowDialog() != DialogResult.OK)
                throw new OperationCanceledException("Image Cancelled");

            return item;
        }

        public static Item ConfirmDetailsBeforeSaving(this Item item)
        {
            var form = new ConfirmNewItemDetails(item);

            if (form.ShowDialog() != DialogResult.OK)
                throw new OperationCanceledException("Last Step Cancelled");

            return item;
        }
    }
}
