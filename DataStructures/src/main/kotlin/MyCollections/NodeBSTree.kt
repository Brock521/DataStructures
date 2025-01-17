package MyCollections

import com.sun.source.tree.BinaryTree

class NodeBSTree<E : Comparable<E>> {
    inner class  Node<E>(var value: E)  {
        var left: Node<E>? = null
        var right: Node<E>? = null
    }

    var root:Node<E>? = null
    var size: Int = 0

     fun isEmpty(): Boolean {
        return size <= 0;
    }

     fun inOrderTraversal(node: Node<E>?, nodesList:MutableList<E> = mutableListOf()) : MutableList<E> {

         if(node != null) {
             inOrderTraversal(node.left,nodesList)
             nodesList.add(node.value)
             inOrderTraversal(node.right,nodesList)
         }

         return nodesList

    }

     fun preOrderTraversal(node: Node<E>?, nodesList:MutableList<E> = mutableListOf()) : MutableList<E>  {

         if(node != null) {
             nodesList.add(node.value)
             preOrderTraversal(node.left,nodesList)
             preOrderTraversal(node.right,nodesList)
         }

         return nodesList

    }

     fun postOrderTraversal(node: Node<E>?, nodesList:MutableList<E> = mutableListOf()) : MutableList<E> {

         if(node != null) {
             postOrderTraversal(node.left,nodesList)
             preOrderTraversal(node.right,nodesList)
             nodesList.add(node.value)
         }
         return nodesList
    }

    fun remove(value: E) {

        if(root != null) {
             removeRecursive(root, value)
        }
    }

    fun smallestValue(rootNode: Node<E>): E {
        val leftNode = rootNode.left
        if (leftNode === null) return rootNode.value
        return smallestValue(leftNode)
    }


    fun removeRecursive(currentNode: Node<E>?, value: E): Node<E>? {
            if (currentNode == null) {
                return null
            }

            if (value == currentNode.value) {
                if (currentNode.left == null && currentNode.right== null) {
                    return null
                }
                if (currentNode.left == null) {
                    return currentNode.right
                }
                if (currentNode.right == null) {
                    return currentNode.left
                }

                val smallestValue = smallestValue(currentNode.right!!)
                currentNode.value = smallestValue
                currentNode.right = removeRecursive(currentNode.right, smallestValue)
                return currentNode
            }

            if (value < currentNode.value) {
                currentNode.left = removeRecursive(currentNode.left, value)
            } else {
                currentNode.right = removeRecursive(currentNode.right, value)
            }

            return currentNode

    }

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