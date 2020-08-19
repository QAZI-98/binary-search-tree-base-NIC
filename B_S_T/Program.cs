using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace B_S_T
{
    class Program
    {
        class node
        {
            public node right;
            public node left;
            public int key;
            public node(int _key)
            { key = _key; }
       

        }

        class binary_tree
        {
            public node root;

            public void insert_(int key)
            {
                int iterations = 0;
                node new_node = new node(key);
                
                if (root == null)
                {
                    iterations++;
                    Console.WriteLine("\t" + key + " inserted as root\t\t# of visited elements " + iterations);
                    root = new_node;
                }

                else
                {

                    node temp = root;
                    node parent = null;

                    while (true)
                    {
                        parent = temp;

                        if (key <= parent.key)
                        {
                            temp = temp.left;
                            iterations++;
                            if (temp == null)
                            {
                                Console.WriteLine("\t" + key + " inserted as left child of " + parent.key + "\t# of visited elements:" + iterations);
                                parent.left = new_node;
                                break;
                            }
                        }
                        
                        if (key > parent.key)
                        {
                            iterations++;
                            temp = temp.right;
                            if (temp == null)
                            {
                                Console.WriteLine("\t"+key + " inserted as right child of " + parent.key+"\t# of visited elements:" + iterations  );
                                parent.right = new_node;
                                break;
                            }
                        }

                    }
                }
            }

            public void delete(int _key)
            {
                if (root==null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("No elements in the tree");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    return;
                    
                }

                node current = root;
                node parent = null;
                while (current != null)
                {
                    if (current.key == _key)
                    {
                        break;
                    }
                    parent = current;
                    if (_key < current.key)
                    {
                        current = current.left;
                    }
                    else if (_key > current.key)
                    {
                        current = current.right;
                    }

                }
                
                if (current==null)
                {
                    Console.WriteLine("element is not present in the tree");
                    return;
                }
                
                //case element has 2 children
                //find in order sucessor and its parents
                node temp, temp1;
                if (current.right!=null && current.left!=null)
                {
                   temp1 = current;
                   temp = current.right;
                   while (temp.left!=null)
                   {
                       temp1 = temp;
                       temp = temp.left;
                       
                   }
                   current.key = temp.key;
                   current = temp;
                   parent = temp1;
                   Console.WriteLine("deleted");
                }
                

                //other case 1 or no child
                node temp2;
                if (current.left!=null)
                {
                    temp2 = current.left;
                }
                else
                {
                    temp2 = current.right; 
                }
                if (parent==null)
                {
                    root = temp2;
                }
                else if(current==parent.left)
                {
                    parent.left = temp2;

                }
                else
                {
                    parent.right = temp2;
                }


            }

            public void search(int _key)
            {
                if (root == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("no elements to in the tree");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                }

                else
                {

                    int count = 0;
                    node temp = root;
                    node parent = null;
                    while (true)
                    {
                       
                        parent = temp;
                        Console.WriteLine("visited elements: " + parent.key);
                        if (_key < parent.key)
                        {
                            temp = temp.left;
                            count++;
                        }

                        if (_key > parent.key)
                        {
                            temp = temp.right;
                            count++;
                        }

                        if (parent.key == _key)
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(_key + " element found in the tree");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        }

                        if (temp == null)
                        {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("element not found in the tree");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        }

                    }
                    Console.WriteLine("no of visited elements <{0}>", count);


                }
            }

            public void in_order_traverse(node temp)
            {

                if (temp != null)
                {
                    in_order_traverse(temp.left);
                    Console.WriteLine(temp.key);
                    in_order_traverse(temp.right);
                }
                
            }


            public void pre_order_traverse(node temp)
            {

                if (temp != null)
                {
                    Console.WriteLine(temp.key);
                    pre_order_traverse(temp.left);
                    pre_order_traverse(temp.right);
                }

            }

            public void post_order_traverse(node temp)
            {

                if (temp != null)
                {
                    post_order_traverse(temp.left);
                    post_order_traverse(temp.right);
                    Console.WriteLine(temp.key);
                }

            }

       
            }

            static void Main(string[] args)
          {
            
            binary_tree bst = new binary_tree();
            
                int op = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("     \t<------------------Binary Search Tree---------------->");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\t\t\t\t\t\t\t\tBig Oh O(n)\n\t\t\t\t\t\t\t\tTheta log(n)\n\t\t\t\t\t\t\t\tOmega 0(1)");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.ResetColor();
                do
                {

                    Console.WriteLine("1)press 1 to insert element in the tree");
                    Console.WriteLine("2)press 2 to search element in the tree");
                    Console.WriteLine("3)press 3 for deletion");
                    Console.WriteLine("4)press 4 for In Order traversing");
                    Console.WriteLine("5)press 5 for Pre Order traversing");
                    Console.WriteLine("6)press 6 for Post Order traversing");
                    Console.WriteLine("7)press 7 to create NIC");
                    Console.WriteLine("8)press 8 to compare searching efficiencies");
                    Console.WriteLine();
                    try
                    {

                        op = int.Parse(Console.ReadLine());
                        if (op == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("enter element to insert");
                            int el = int.Parse(Console.ReadLine());
                            bst.insert_(el);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        if (op == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("enter element to search");
                            int el = int.Parse(Console.ReadLine());
                            bst.search(el);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        if (op == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("enter element to delete");
                            int el = int.Parse(Console.ReadLine());
                            bst.delete(el);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        if (op == 4)
                        {
                            if (bst.root != null)
                            {

                                Console.Clear();
                                Console.WriteLine("\nIN Order Traversing");
                                bst.in_order_traverse(bst.root);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("tree is empty");
                            }
                        }
                        if (op == 5)
                        {
                            if (bst.root != null)
                            {

                                Console.Clear();
                                Console.WriteLine("\nPre order Traversing");
                                bst.pre_order_traverse(bst.root);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("tree is empty");
                            }
                        }

                        else if (op == 6)
                        {
                            if (bst.root != null)
                            {
                                Console.Clear();
                                Console.WriteLine("\nPost order Traversing");
                                bst.post_order_traverse(bst.root);
                                Console.ReadKey();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("tree is empty");
                            }
                       
                        }
                        else if (op==8)
                        {
                            Console.Clear();
                            Console.WriteLine("eneter # of random elements to insert");
                            int rno = int.Parse(Console.ReadLine());
                            Random r = new Random();
                            int[] arr = new int[rno];
                            for (int i = 0; i < rno; i++)
                            {
                                int x = r.Next(0, 1000);
                                arr[i] = x;
                                bst.insert_(x);
                            }
                            int count = 0;
                            for (int i = 0; i < arr.Length; i++)
                            {
                                count++;
                                if (arr[i] == 93)
                                {
                                    break;
                                }

                            }

                            Console.WriteLine("\n\tWe inserted "+rno+" random elements in an array and the binary search tree");
                            Console.WriteLine("\nno of visited elements in linear searching " + count);
                            Console.WriteLine("\nNow searching  the same number in the binary search tree\n");
                            bst.search(93);
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else if(op==7)
                        {
                            Console.Clear();
                            nic nic = new nic();
                            int op1 = 0;
                            do
                            {
                                Console.WriteLine("press 1 to create");
                                Console.WriteLine("press 2 to search");
                                Console.WriteLine("press 3 to view");
                                Console.WriteLine("press 4 to delete");

                                op1 = int.Parse(Console.ReadLine());
                                if (op1 == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine("enter new nic number");
                                    int nicc = int.Parse(Console.ReadLine());
                                    Console.WriteLine("enter name ");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("enter dob");
                                    string dob = Console.ReadLine();
                                    Console.WriteLine("enter adress");
                                    string adress = Console.ReadLine();
                                    nic.insert(nic.root, nicc, name, dob, adress);
                                    Console.WriteLine("inserted!");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                                if (op1 == 2)
                                {
                                    Console.WriteLine("enter nic# to search");
                                    int nicc = int.Parse(Console.ReadLine());

                                    nod temp=nic.search_recursively(nicc,nic.root);
                                    if (temp!=null)
                                    {
                                        Console.WriteLine("found");
                                        Console.WriteLine("\tname:{0}\tDOB:{1}\tadress:{2}",temp.name,temp.dob,temp.adress);
                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine("not found");
                                    }
                                    Console.ReadKey();
                                }

                                if (op1==3)
                                {
                                    Console.WriteLine("\n\tID card#\tname\tDOB\tadress");
                                    nic.in_order_traverse(nic.root);
                                    Console.ReadKey();
                                }

                            } while (op1!=0);
                            Console.Clear();
                            
                            
                        }




                    
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        op = 7;
                    }

                    //if root null dont traverse


                } while (op != 0);

                Console.ReadKey();






            }

        }
    }
