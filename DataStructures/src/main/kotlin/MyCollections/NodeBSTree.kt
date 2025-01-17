package MyCollections

/*This is a typical implementation of a Binary Search Tree using nodes
* It contains a Node inner class and functions needed to add, remove, search, and traverse the tree
* */

class NodeBSTree<E : Comparable<E>> {
    inner class  Node<E>(var value: E)  {
        var left: Node<E>? = null
        var right: Node<E>? = null
    }

    var root:Node<E>? = null
    var size: Int = 0

    /*Return true if the tree has node
    * O(1)
    * */
     fun isEmpty(): Boolean {
        return size <= 0;
    }

    /*
    * Left subtree then root then right subtree
    * O(n)
    * */
     fun inOrderTraversal(node: Node<E>?, nodesList:MutableList<E> = mutableListOf()) : MutableList<E> {
         if(node != null) {
             inOrderTraversal(node.left,nodesList)
             nodesList.add(node.value)
             inOrderTraversal(node.right,nodesList)
         }
         return nodesList
    }

    /*
    * Visit the root then left subtree then right
    * O(n)
    * */
     fun preOrderTraversal(node: Node<E>?, nodesList:MutableList<E> = mutableListOf()) : MutableList<E>  {
         if(node != null) {
             nodesList.add(node.value)
             preOrderTraversal(node.left,nodesList)
             preOrderTraversal(node.right,nodesList)
         }
         return nodesList
    }

    /*
   * Visit the left subtree then right then root
   * O(n)
   * */
     fun postOrderTraversal(node: Node<E>?, nodesList:MutableList<E> = mutableListOf()) : MutableList<E> {
         if(node != null) {
             postOrderTraversal(node.left,nodesList)
             preOrderTraversal(node.right,nodesList)
             nodesList.add(node.value)
         }
         return nodesList
    }

    /*Calls return recursive to remove the node with the matching and return true if a node was removed.
    * O(n) in the case that there is only a single branch. Θ(logn) on average
    */
    fun remove(value: E) : Boolean{
        val initialSize = size
        if(root != null) {
             removeRecursive(root, value)
        }
        return initialSize != size
    }

    /*Returns the smallest value in the tree ie)The left most leaf
    * O(n) in the case that there is only a single branch. Θ(logn) on average
    */
    private fun smallestValue(rootNode: Node<E>): E {
        val leftNode = rootNode.left
        if (leftNode === null) return rootNode.value
        return smallestValue(leftNode)
    }

    /*
    *
    * */
    private fun removeRecursive(currentNode: Node<E>?, value: E): Node<E>? {

            //Base case
            if (currentNode == null) {
                return null
            }

            //If value is found
            if (value.compareTo(currentNode.value) == 0) {
                //And there is a child Node
                if (currentNode.left == null && currentNode.right== null) {
                    return null
                }
                //Return right if left does not exist
                if (currentNode.left == null) {
                    return currentNode.right
                }
                //Return left if right does not exist
                if (currentNode.right == null) {
                    return currentNode.left
                }

                //If two children exist find the smallest value in the right subtree
                val smallestValue = smallestValue(currentNode.right!!)
                //Replace the value of the current node with the smallest value
                currentNode.value = smallestValue
                //Remove the node with the same value to remove the duplicate
                currentNode.right = removeRecursive(currentNode.right, smallestValue)
                size--;
                //Return the updated node
                return currentNode
            }

            //If the value is less traverse left
            if (value.compareTo(currentNode.value) < 0) {
                currentNode.left = removeRecursive(currentNode.left, value)
            }
            //Other traverse right
            else {
                currentNode.right = removeRecursive(currentNode.right, value)
            }

            //Return node passed in
            return currentNode

    }

    /*
    * Inserts a value as a leaf. Smaller values go down the subtree left, Larger values go down the right subtree
    * Returns true if the value was insert and false if no changes were made
    * O(n) in the case that there is only a single branch. Θ(logn) on average
    * */
     fun insert(value: E): Boolean {
        if (isEmpty()) {
            root = Node(value)
            size++
            return true
        }

        var currNode = root

        while (true) {
            val comparison = value.compareTo(currNode!!.value)

            if (comparison < 0) { // Go to the left subtree
                if (currNode.left == null) {
                    currNode.left = Node(value)
                    size++
                    return true
                } else {
                    currNode = currNode.left
                }
            } else if (comparison > 0) { // Go to the right subtree
                if (currNode.right == null) {
                    currNode.right = Node(value)
                    size++
                    return true
                } else {
                    currNode = currNode.right
                }
            } else {
                // Value already exists in the tree
                return false
            }
        }

    }

    /*
    * Search for a value in the tree and return its node. Will return null if the node is not found.
    * O(n) in the case that there is only a single branch. Θ(logn) on average.
    * */
     fun search(value: E): Node<E>? {
        if(isEmpty()) return null

        var currNode = root

        while (currNode != null) {
            val comparison = value.compareTo(currNode.value)

            if (comparison < 0) { // Go to the left subtree
                currNode = currNode.left
            } else if (comparison > 0) { // Go to the right subtree
                currNode = currNode.right
            } else {
                return  currNode
            }
        }
         return null
    }

}