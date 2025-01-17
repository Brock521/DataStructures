import org.junit.jupiter.api.BeforeEach
import org.junit.jupiter.api.Test
import kotlin.test.assertEquals
import kotlin.test.assertNull
import kotlin.test.assertTrue
import kotlin.test.assertFalse
import MyCollections.NodeBSTree

class NodeBSTreeTest {

    private lateinit var tree: NodeBSTree<Int>

    @BeforeEach
    fun setUp() {
        tree = NodeBSTree()
    }

    @Test
    fun testInsert() {
        assertTrue(tree.insert(5))   // Should return true as tree is empty
        assertTrue(tree.insert(3))   // Should return true
        assertTrue(tree.insert(7))   // Should return true
        assertFalse(tree.insert(3))  // Should return false as value 3 already exists
    }

    @Test
    fun testSearch() {
        tree.insert(10)
        tree.insert(5)
        tree.insert(15)

        assertEquals(10, tree.search(10)?.value)  // Should find 10
        assertEquals(5, tree.search(5)?.value)    // Should find 5
        assertNull(tree.search(100))              // Should return null as 100 is not in the tree
    }

    @Test
    fun testRemove() {
        tree.insert(10)
        tree.insert(5)
        tree.insert(15)
        tree.insert(3)
        tree.insert(7)

        tree.remove(5)
        var output =  tree.preOrderTraversal(tree.root)
        assertEquals(listOf(10,7,3,15), output)

        tree.remove(10)
        output = tree.preOrderTraversal(tree.root)
        assertEquals(listOf(15,7,3), output)

        val emptyTree = NodeBSTree<Int>()
        emptyTree.remove(5)
        output = emptyTree.preOrderTraversal(emptyTree.root)
        assertEquals(listOf(), output)
    }

    @Test
    fun testInOrderTraversal() {
        tree.insert(10)
        tree.insert(5)
        tree.insert(15)
        tree.insert(3)
        tree.insert(7)

        // Expected in-order traversal: 3, 5, 7, 10, 15
        val output =  tree.inOrderTraversal(tree.root)

        assertEquals(listOf(3, 5, 7, 10, 15), output)
    }

    @Test
    fun testPreOrderTraversal() {
        tree.insert(10)
        tree.insert(5)
        tree.insert(15)
        tree.insert(3)
        tree.insert(7)

        // Expected pre-order traversal: 10, 5, 3, 7, 15
        val output =  tree.preOrderTraversal(tree.root)

        assertEquals(listOf(10,5,3,7,15), output)
    }

    @Test
    fun testPostOrderTraversal() {
        tree.insert(10)
        tree.insert(5)
        tree.insert(15)
        tree.insert(3)
        tree.insert(7)

        // Expected post-order traversal: 3, 7, 5, 15, 10
        val output = tree.postOrderTraversal(tree.root)

        assertEquals(listOf(3, 7, 5, 15, 10), output)
    }

}
