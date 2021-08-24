// PlayerCharacterTests
// Tests the character that the player controls

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerCharacterTests
{
    GameObject gameObject;
    PlayerCharacter player;
    Transform transform;

    [SetUp]
    public void BeforeEveryTest()
    {
        gameObject = new GameObject();
        player = gameObject.AddComponent<PlayerCharacter>();
        transform = player.transform;
    }

    [TearDown]
    public void AfterEveryTest()
    {
        Object.DestroyImmediate(gameObject);
    }

    public class TheWalkMethod: PlayerCharacterTests
    {
        [Test]
        public void MovesPlayerRight()
        {
            float oldX = transform.position.x;

            player.Walk(Move.Right);

            float newX = transform.position.x;
            Assert.IsTrue(oldX + player.WalkSpeed * (int) Move.Right == newX);
        }

        [Test]
        public void MovesPlayerLeft()
        {
            float oldX = transform.position.x;

            player.Walk(Move.Left);

            float newX = transform.position.x;
            Assert.IsTrue(oldX + player.WalkSpeed * (int) Move.Left == newX);
        }

        [Test]
        public void StaysInsideRightBound()
        {
            // walk "past" the right boundary
            for (float distance = 0; distance <= player.rightBoundary + 1; distance += player.WalkSpeed * (int) Move.Right)
                player.Walk(Move.Right);

            float newX = transform.position.x;
            Assert.IsTrue(newX <= player.rightBoundary);
        }
    }
}