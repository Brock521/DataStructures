package MyCollections

import kotlin.NoSuchElementException

class Stack<E>(var stack: MutableList<E> = mutableListOf()){
    /*Typical stack implementation with a list container. Stacks demonstrate LIFO(Last-In-First-Out) principles
    * meaning only the most recently added items can be removed. The final element in the list represents the top of the
    * stack so that insertion and deletion only need to one operation and not shift the elements to accommodate the
    * change
    * */

    var size = 0

    init{
        size = stack.size;
    }

    /*Adds an element to the top of the stack
    * O(1)
    * */
     fun push(element: E) {
        stack.addLast(element)
    }

    /*Removes the element from the top of the stack and returns that element
   * O(1)
   * */
     fun pop(): E {
         if(isEmpty())throw NoSuchElementException("Stack is empty")
         return stack.removeLast()
    }

    /*Returns the item at the top of the stack
   * O(1)
   * */
     fun peek(): E {
         if(isEmpty())throw NoSuchElementException("Stack is empty")
         return stack.last()
    }

    /*Returns true is the stack has no elements in it and false if there is
   * O(1)
   * */
     fun isEmpty(): Boolean {
        return size<=0
    }

    /*Returns the position of the element is supplied as an argument. Will return -1 if the element is not found
    *O(n)
    * */
     fun search(element: E): Int {
         if(isEmpty())throw NoSuchElementException("Stack is empty")
         return stack.indexOf(element)
    }

    /*
    * Returns an iterator of the current stack
    *
    * */
    fun iterator(): MutableIterator<E> = ListQueueIterator()

    inner class ListQueueIterator : MutableIterator<E> {
        private var currentIndex = 0
        private var lastReturnedIndex = -1 // Tracks the index of the last returned element


        override fun hasNext(): Boolean {
            return currentIndex < stack.size
        }

        override fun next(): E {
            if (!hasNext()) throw NoSuchElementException("No more elements in the queue")
            lastReturnedIndex = currentIndex
            return stack[currentIndex++]
        }

        override fun remove() {
            if (lastReturnedIndex == -1) {
                throw IllegalStateException("remove() called before next() or after already removed")
            }
            stack.removeAt(lastReturnedIndex)
            currentIndex = lastReturnedIndex
            lastReturnedIndex = -1
        }
    }

}