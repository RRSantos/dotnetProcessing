using dotnetProcessing.Core;
using dotnetProcessing.Event;
using System;
using Xunit;


namespace dotnetProcessing.Tests.Event
{
    public class BaseEventTests
    {
        [Fact]
        public void ShowReturnNoModifiersPressed()
        {
            BaseEvent pEvent = new BaseEvent(PEventType.KEY_DOWN, BaseEvent.NONE);

            Assert.False(pEvent.IsAltDown);
            Assert.False(pEvent.IsCtrlDown);
            Assert.False(pEvent.IsShiftDown);

        }

        [Fact]
        public void ShowReturnAltPressed()
        {
            BaseEvent pEvent = new BaseEvent(PEventType.KEY_DOWN, BaseEvent.ALT);

            Assert.True(pEvent.IsAltDown);
            Assert.False(pEvent.IsCtrlDown);
            Assert.False(pEvent.IsShiftDown);
        }

        [Fact]
        public void ShowReturnShiftPressed()
        {
            BaseEvent pEvent = new BaseEvent(PEventType.KEY_DOWN, BaseEvent.SHIFT);

            Assert.False(pEvent.IsAltDown);
            Assert.False(pEvent.IsCtrlDown);
            Assert.True(pEvent.IsShiftDown);
        }

        [Fact]
        public void ShowReturnCtrlPressed()
        {
            BaseEvent pEvent = new BaseEvent(PEventType.KEY_DOWN, BaseEvent.CTRL);

            Assert.False(pEvent.IsAltDown);
            Assert.True(pEvent.IsCtrlDown);
            Assert.False(pEvent.IsShiftDown);
        }

        [Fact]
        public void ShowReturnAltShiftCtrlModifiersPressed()
        {
            BaseEvent pEvent = new BaseEvent(PEventType.KEY_DOWN, BaseEvent.CTRL | BaseEvent.ALT | BaseEvent.SHIFT);            

            Assert.True(pEvent.IsAltDown);
            Assert.True(pEvent.IsCtrlDown);
            Assert.True(pEvent.IsShiftDown);
        }
    }
}
