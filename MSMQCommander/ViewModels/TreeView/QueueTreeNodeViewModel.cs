﻿using System.Messaging;
using Caliburn.Micro;
using MSMQCommander.Utils;

namespace MSMQCommander.ViewModels
{
    public class QueueTreeNodeViewModel : PropertyChangedBase
    {
        private readonly MessageQueue _messageQueue;
        private bool _isExpanded;
        private bool _isSelected;

        public QueueTreeNodeViewModel(MessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public string Name
        {
            get { return _messageQueue.QueueNameExcludingQueueType(); }
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    NotifyOfPropertyChange(() => IsExpanded);
                }
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    NotifyOfPropertyChange(() => IsSelected);
                }
            }
        }
    }
}