using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Helpers
{
    public class TreeConverter<T>
    {
        public  List<TreeNode<T>> NodeBredFirstTraversal(TreeNode<T> root)
        {
           //This will remain here until I implement the same for nodes, then this can be removed, will add a functions here to handle back and forth conversion later
           //There is probably a more efficient method than stripping all of the data then rebuilding but that is a later issue.
           
            List<TreeNode<T>> retrievedData = new List<TreeNode<T>>();

            if (root == null) throw new ArgumentNullException("root");
                
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> current = queue.Dequeue();
                retrievedData.Add(current);

                if (current.GetChildren().Count > 2)
                {
                    throw new ArgumentOutOfRangeException("To many Children");
                }

                foreach (var child in current.GetChildren())
                {
                    queue.Enqueue(child);
                }
            }

            return retrievedData;
           
        }


    }
}
