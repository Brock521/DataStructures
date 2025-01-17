package MyCollections

import java.util.*
import java.util.Stack
import kotlin.NoSuchElementException

class Stack<E>(var stack: MutableList<E> = mutableListOf()){

    var size = 0

    init{
        size = stack.size;
    }

     fun push(element: E) {
        stack.addLast(element)
    }

     fun pop(): E {
         if(isEmpty())throw NoSuchElementException("Stack is empty")
         return stack.removeLast()
    }

     fun peek(): E {
         if(isEmpty())throw NoSuchElementException("Stack is empty")
         return stack.last()
    }


     fun isEmpty(): Boolean {
        return size<=0
    }

     fun search(element: E): Int {
         if(isEmpty())throw NoSuchElementException("Stack is empty")
         return stack.indexOf(element)
    }

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