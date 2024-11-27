using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Game10003
{
    public class Collision
    {
        /// <summary>
        ///     Detects when a point is within the bounds of a rectangle
        /// </summary>
        /// <param name="pointPosition">Position of the point</param>
        /// <param name="shape">Position of the rectangle</param>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
        /// <returns></returns>
        public bool IsPointInRectangle(Vector2 pointPosition, Vector2 shape, float width, float height)
        {
            float shapeLeftSide, shapeRightSide, shapeTopSide, shapeBottomSide;
            bool isPointInShapeWidth, isPointInShapeHeight;

            shapeLeftSide = shape.X;
            shapeRightSide = shape.X + width;
            shapeTopSide = shape.Y;
            shapeBottomSide = shape.Y + height;

            isPointInShapeWidth = pointPosition.X > shapeLeftSide && pointPosition.X < shapeRightSide;
            isPointInShapeHeight = pointPosition.Y > shapeTopSide && pointPosition.Y < shapeBottomSide;

            return isPointInShapeHeight && isPointInShapeWidth;
        }

        /// <summary>
        ///     Detects if one rectangle is in another rectangle
        /// </summary>
        /// <returns></returns>
        public bool IsRectangleInRectangle(Vector2 shape1, float shape1Width, float shape1Height, Vector2 shape2, float shape2Width, float shape2Height)
        {
            float shape1LeftSide, shape1RightSide, shape1TopSide, shape1BottomSide;
            float shape2LeftSide, shape2RightSide, shape2TopSide, shape2BottomSide;

            shape1LeftSide = shape1.X;
            shape1RightSide = shape1.X + shape1Width;
            shape1TopSide = shape1.Y;
            shape1BottomSide = shape1.Y + shape1Height;

            shape2LeftSide = shape2.X;
            shape2RightSide = shape2.X + shape2Width;
            shape2TopSide = shape2.Y;
            shape2BottomSide = shape2.Y + shape2Height;

            bool isShape1WithinShape2Width, isShape1WithinShape2Height;

            isShape1WithinShape2Width = shape1LeftSide <= shape2RightSide && shape1RightSide >= shape2LeftSide;
            isShape1WithinShape2Height = shape1TopSide <= shape2BottomSide && shape1BottomSide >= shape2TopSide;

            return isShape1WithinShape2Height && isShape1WithinShape2Width;
        }
    }
}
