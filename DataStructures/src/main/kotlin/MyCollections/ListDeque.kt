package MyCollections

import java.util.*

/*
* This is a deque structure implemented using a list. The dequeue provides functions to add and peek on both ends of the
* list. A deque can be used to emulate FIFO (First-in-First-Out) principles using only the queue functions or
* LIFO (Last-In-First-Out) principles of a stack using a subset of the other deque functions but is not necessary.
*
* FIFO functions:
*   poll()
*   add()
*   peek()
*
* LIFO functions:
*   add()
*   pollLast()
*   peekLast()
*
* */


class ListDeque<E>(private var deque: MutableList<E> = mutableListOf()) : Deque<E> {

    override val size: Int
        get() = deque.size

    /*
    *Returns true if any elements are in the deque. Otherwise returns false
    * O(1)
    */
    override fun isEmpty(): Boolean {
        return size > 0
    }

    /*******************************Start Queue Functions***********************************/


    /*
    *Return and removes the first element in the deque. Will return null if the list is empty
    *O(n) - All elements must be shifted after the first element is removed
    * */
    override fun poll(): E? {
        if (isEmpty()) return null
        return deque.removeFirst()
    }

    /*
    *Returned the first element in the deque. Will throw a NoSuchElementException if the deque is empty.
    * O(1)
     */
    override fun element(): E {
        if (isEmpty()) throw NoSuchElementException("There is no element to retrieve from the deque")
        return peek()
    }

    /*
    *Returned the first element in the deque even if it is null
    * O(1)
    */
    override fun peek(): E {
        return deque.first()
    }

    /*
   *Add an element to the deque.
   * O(1)
   */
    override fun offer(e: E): Boolean {
        return add(e)
    }

    /*
    *Add an element to the deque.
    * O(1)
    */
    override fun add(element: E): Boolean {
        deque.addLast(element)
        return true
    }


    /*
    * Add all elements from the elements argument into the deque in the order they are provided and return true if any
    * changes were made. False otherwise.
    * O(m) where m is the number of elements provided in the elements argument
    * */
    override fun addAll(elements: Collection<E>): Boolean {

        var initialSize = size

        for (element in elements) {
            deque.add(element)
        }

        return initialSize != size
    }


    /*
    * Removes all elements from the deque while size > 0
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
    override fun iterator(): MutableIterator<E> = ListdequeIterator()

    inner class ListdequeIterator : MutableIterator<E> {
        private var currentIndex = 0
        private var lastReturnedIndex = -1 // Tracks the index of the last returned element


        override fun hasNext(): Boolean {
            return currentIndex < deque.size
        }

        override fun next(): E {
            if (!hasNext()) throw NoSuchElementException("No more elements in the deque")
            lastReturnedIndex = currentIndex
            return deque[currentIndex++]
        }

        override fun remove() {
            if (lastReturnedIndex == -1) {
                throw IllegalStateException("remove() called before next() or after already removed")
            }
            deque.removeAt(lastReturnedIndex)
            currentIndex = lastReturnedIndex
            lastReturnedIndex = -1
        }
    }

    /*
    * Removes the first item from the deque and returns the element. Will return null if there are no elements to remove.
    * O(n) as we have to shuffle the elements
    * */
    override fun remove(): E? {
        if (isEmpty()) return null
        return deque.removeFirst()
    }

    /*
    * Removes all elements that are not contained in the elements collection provided as an argument. Returns true
    * if any changes were made and false if none. Note here all elements in the deque that match a single element in
    * the elements argument will be kept.
    *
    * */
    override fun retainAll(elements: Collection<E>): Boolean {
        val initialSize = size

        deque = deque.filter { it in elements }.toMutableList()
        return deque.size != initialSize
    }

    /*
    * Removes all elements that are contained in the elements collection provided as an argument. Returns true
    * if any changes were made and false if none. Note here all elements including repetitions in the deque that match
    * a single element in the elements argument will be removed.
    *  O(n * m) where n is the number of elements in the deque and m is the number of elements in the elements arg
    */
    override fun removeAll(elements: Collection<E>): Boolean {
        val initialSize = size

        deque = deque.filterNot { it in elements }.toMutableList()
        return deque.size != initialSize
    }

    /*
    * Removes an element at a specified index and returns true if the element exists. False otherwise.
    * O(n)
    * */
    override fun remove(element: E): Boolean {
        if (contains(element) == false) return false
        return deque.remove(element)
    }

    /*
    *Returns true if all elements supplied in the argument are found in the deque. Returns true if the deque is changed
    *and false otherwise;
    * O(n * m) where n is the number of elements in the deque and m is the number of elements in the elements arg
     */
    override fun containsAll(elements: Collection<E>): Boolean {

        val initialSize = size
        return initialSize == deque.filter { it -> it in elements }.toMutableList().size

    }

    /*
    * Returns true if the element provided in the argument is in the deque and false otherwise
    * O(1)
    * */
    override fun contains(element: E): Boolean {
        return deque.indexOf(element) >= 0
    }

    /*************************End queue Functions *************************************/

    /*Functionally the same as peek(). Return the first element in the deque
    * O(1)
    * */
    override fun getFirst(): E {
        return peek()
    }

    /*
    * Returns the last element in the deque if it exists or throws an error if the deque is empty
    * O(1)
    * */
    override fun getLast(): E {
        if(isEmpty() == true)throw NoSuchElementException("The deque is empty");
        return deque.last()
    }

    /*
    * With return the first element in the deque if it exists or thrown an error if the deque is empty
    * O(1)
    * */
    override fun removeFirst(): E {
        if(isEmpty() == true)throw NoSuchElementException("The deque is empty");
        return deque.removeFirst()
    }

    /*
    * Removes the last element in the deque if it exists or throws an error if it is empty
    * O(1)
    * */
    override fun removeLast(): E {
        if(isEmpty() == true)throw NoSuchElementException("The deque is empty");
        return deque.removeLast()
    }

    /*
    * Removes and returns the first element in the deque if it exists or null if the deque is empty
    * O(n) as we must shift towards the front after removing the first element
    * */
    override fun pollFirst(): E? {
        if(isEmpty() == true) return null
        return deque.removeFirst()
    }

    /*
    * Removes and returns the first element in the deque if it exists or null if the deque is empty
    * O(1) simply remove the last element
    * */
    override fun pollLast(): E? {
        if(isEmpty() == true) return null
        return deque.removeLast()
    }

    /*Return the first element of the deque or null if no element exists
    * O(1)
    * */
    override fun peekFirst(): E? {
        if(isEmpty() == true) return null
        return deque.first()
    }

    /*Return the last element of the deque or null if no element exists
    * O(1)
    * */
    override fun peekLast(): E? {
        if(isEmpty() == true) return null
        return deque.last()
    }

    /*Removes the first occurrence of a given element in the deque and returns true if a change was made.
    * O(n) as we must shift all elements forward if the first element is removed
    * */
    override fun removeFirstOccurrence(o: Any?): Boolean {
        val targetElement = o as? E ?: return false
        val initialSize = size

        deque.remove(targetElement)
        return initialSize != size
    }

    /*Removes the last occurrence of a given element in the deque and returns true if a change was made.
    * O(n) as we must shift all elements forward if the only occurrence of the element is the element at the first index
    * */
    override fun removeLastOccurrence(o: Any?): Boolean {
        val targetElement = o as? E ?: return false
        val initialSize = size

        for (elementIndex in initialSize - 1 downTo 0) { // Use downTo for descending iteration
            if(deque.get(elementIndex) == targetElement){
                deque.removeAt(elementIndex)
                return true
            }
        }

        return false
    }

    /*
    * Removes the first element in the deque and returns it.
    * O(n) to shift all elements forward.
    * */
    override fun pop(): E {
       return deque.removeFirst()
    }

    /*
    * Like the other iterator added in this class but in the reverse direction
    * */
    override fun descendingIterator(): MutableIterator<E> = dequeDescendingIterator()

    inner class dequeDescendingIterator() : MutableIterator<E>{
        private var currentIndex = deque.size-1
        private var lastReturnedIndex = -1 // Tracks the index of the last returned element


        override fun hasNext(): Boolean {
            return currentIndex >= 0
        }

        override fun next(): E {
            if (!hasNext()) throw NoSuchElementException("No more elements in the deque")
            lastReturnedIndex = currentIndex
            return deque[currentIndex--] // Access element, then decrement
        }

        override fun remove() {
            if (lastReturnedIndex == -1) {
                throw IllegalStateException("remove() called before next() or after already removed")
            }
            deque.removeAt(lastReturnedIndex)
            currentIndex = lastReturnedIndex - 1
            lastReturnedIndex = -1
        }


    }

    /*
    * Adds the provided element into the first position in the deque
    * O(n) as we must shift all elements towards the back of the deque to open up the first position
    * */
    override fun push(e: E) {
        return deque.addFirst(e)
    }

    /*
   * Adds the provided element at back end of the deque. Returns true if the deque was changed and false otherwise
   * O(1)
   * */
    override fun offerLast(e: E): Boolean {
        val initialSize = size
        addLast(e)
        return initialSize != size
    }

    /*
     * Adds the provided element into the first position in the deque and returns true if a change was made. False otherwise
     * O(n) as we must shift all elements towards the back of the deque to open up the first position
    * */
    override fun offerFirst(e: E): Boolean {
        val initialSize = size
        addFirst(e)
        return initialSize != size
    }

    /*
    * Adds the provided element at back end of the deque. Returns true if the deque was changed and false otherwise
    * O(1)
    * */
    override fun addLast(e: E) {
        deque.add(e)
    }

    /*
  * Adds the provided element at front end of the deque. Returns true if the deque was changed and false otherwise
  * O(1)
  * */
    override fun addFirst(e: E) {
        deque.add(0,e)
    }



}