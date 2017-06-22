﻿// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

using System.Numerics;

namespace Microsoft.Toolkit.Uwp.UI.Animations.Expressions
{
    // Ignore warning: 'QuaternionNode' defines operator == or operator != but does not override Object.Equals(object o) && Object.GetHashCode()
#pragma warning disable CS0660, CS0661
    public sealed class QuaternionNode : ExpressionNode
    {
        internal QuaternionNode()
        {
        }

        internal QuaternionNode(Quaternion value)
        {
            _value = value;
            NodeType = ExpressionNodeType.ConstantValue;
        }

        internal QuaternionNode(string paramName)
        {
            ParamName = paramName;
            NodeType = ExpressionNodeType.ConstantParameter;
        }

        internal QuaternionNode(string paramName, Quaternion value)
        {
            ParamName = paramName;
            _value = value;
            NodeType = ExpressionNodeType.ConstantParameter;

            SetQuaternionParameter(paramName, value);
        }

        public static implicit operator QuaternionNode(Quaternion value)
        {
            return new QuaternionNode(value);
        }

        public static QuaternionNode operator *(QuaternionNode left, ScalarNode right)
        {
            return ExpressionFunctions.Function<QuaternionNode>(ExpressionNodeType.Multiply, left, right);
        }

        public static QuaternionNode operator *(QuaternionNode left, QuaternionNode right)
        {
            return ExpressionFunctions.Function<QuaternionNode>(ExpressionNodeType.Multiply, left, right);
        }

        public static QuaternionNode operator /(QuaternionNode left, QuaternionNode right)
        {
            return ExpressionFunctions.Function<QuaternionNode>(ExpressionNodeType.Divide, left, right);
        }

        public static BooleanNode operator ==(QuaternionNode left, QuaternionNode right)
        {
            return ExpressionFunctions.Function<BooleanNode>(ExpressionNodeType.Equals, left, right);
        }

        public static BooleanNode operator !=(QuaternionNode left, QuaternionNode right)
        {
            return ExpressionFunctions.Function<BooleanNode>(ExpressionNodeType.NotEquals, left, right);
        }

        protected internal override string GetValue()
        {
            return $"Quaternion({_value.X},{_value.Y},{_value.Z},{_value.W})";
        }

        private Quaternion _value;
    }
#pragma warning restore CS0660, CS0661
}