package MyCollections

import java.util.Queue


/*
* This class is the standard implementation of a Queue using a List
*/

class ListQueue<E>(private var queue: MutableList<E> = mutableListOf()) : Queue<E> {


    override val size: Int
        get() = queue.size

    /*
    *Returns true if any elements are in the queue. Otherwise returns false
    * O(1)
    */
    override fun isEmpty(): Boolean {
        return size > 0
    }

    /*
    *Return and removes the first element in the queue. Will return null if the list is empty
    *O(n) - All elements must be shifted after the first element is removed
    * */
    override fun poll(): E? {
        if (isEmpty()) return null
        return queue.removeFirst()
    }

    /*
    *Returned the first element in the queue. Will throw a NoSuchElementException if the queue is empty.
    * O(1)
     */
    override fun element(): E {
        if (isEmpty()) throw NoSuchElementException("There is no element to retrieve from the queue")
        return peek()
    }

    /*
    *Returned the first element in the queue even if it is null
    * O(1)
    */
    override fun peek(): E {
        return queue.first()
    }

    /*
    *Add an element to the queue.
    * O(1)
    */
    override fun offer(e: E): Boolean {
        return add(e)
    }

    /*
    *Add an element to the queue.
    * O(1)
    */
    override fun add(element: E): Boolean {
        queue.addLast(element)
        return true
    }


    /*
    * Add all elements from the elements argument into the queue in the order they are provided and return true if any
    * changes were made. False otherwise.
    * O(m) where m is the number of elements provided in the elements argument
    * */
    override fun addAll(elements: Collection<E>): Boolean {

        var initialSize = size

        for (element in elements) {
            add(element)
        }

        return initialSize == size
    }


    /*
    * Removes all elements from the queue while size > 0
    * O(n)
    * */
    override fun clear() {

        while (isEmpty() == false) {
            remove()
        }

    }


    /*
    *Returns an Iterator with the ability to go next() or remove() items or check if hasNext()
    * Each function run in O(1) time. A full step through is O(N)
    */
    override fun iterator(): MutableIterator<E> = ListQueueIterator()

    inner class ListQueueIterator : MutableIterator<E> {
        private var currentIndex = 0
        private var lastReturnedIndex = -1 // Tracks the index of the last returned element


        override fun hasNext(): Boolean {
            return currentIndex < queue.size
        }

        override fun next(): E {
            if (!hasNext()) throw NoSuchElementException("No more elements in the queue")
            lastReturnedIndex = currentIndex
            return queue[currentIndex++]
        }

        override fun remove() {
            if (lastReturnedIndex == -1) {
                throw IllegalStateException("remove() called before next() or after already removed")
            }
            queue.removeAt(lastReturnedIndex)
            currentIndex = lastReturnedIndex
            lastReturnedIndex = -1
        }
    }

    /*
    * Removes the first item from the queue and returns the element. Will return null if there are no elements to remove.
    * O(n) as we have to shuffle the elements
    * */
    override fun remove(): E? {
        if (isEmpty()) return null
        return queue.removeFirst()
    }

    /*
    * Removes all elements that are not contained in the elements collection provided as an argument. Returns true
    * if any changes were made and false if none. Note here all elements in the queue that match a single element in
    * the elements argument will be kept.
    *
    * */
    override fun retainAll(elements: Collection<E>): Boolean {
        val initialSize = size

        queue = queue.filter { it in elements }.toMutableList()
        return queue.size != initialSize
    }

    /*
    * Removes all elements that are contained in the elements collection provided as an argument. Returns true
    * if any changes were made and false if none. Note here all elements including repetitions in the queue that match
    * a single element in the elements argument will be removed.
    *  O(n * m) where n is the number of elements in the queue and m is the number of elements in the elements arg
    */
    override fun removeAll(elements: Collection<E>): Boolean {
        val initialSize = size

        queue = queue.filterNot { it in elements }.toMutableList()
        return queue.size != initialSize
    }

    /*
    * Removes an element at a specified index and returns true if the element exists. False otherwise.
    * O(n)
    * */
    override fun remove(element: E): Boolean {
        if (contains(element) == false) return false
        return queue.remove(element)
    }

    /*
    *Returns true if all elements supplied in the argument are found in the queue. Returns true if the queue is changed
    *and false otherwise;
    * O(n * m) where n is the number of elements in the queue and m is the number of elements in the elements arg
     */
    override fun containsAll(elements: Collection<E>): Boolean {

        val initialSize = size
        return initialSize == queue.filter { it -> it in elements }.toMutableList().size

    }

    /*
    * Returns true if the element provided in the argument is in the queue and false otherwise
    * O(1)
    * */
    override fun contains(element: E): Boolean {
        return queue.indexOf(element) >= 0
    }

}

