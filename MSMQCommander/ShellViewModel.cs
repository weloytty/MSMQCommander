﻿using System.Collections.ObjectModel;
using Caliburn.Micro;
using MSMQCommander.Contex;
using MSMQCommander.Events;
using MSMQCommander.Views;
using System.Linq;

namespace MSMQCommander 
{
    public class ShellViewModel : 
        PropertyChangedBase, 
        IShell,
        IHandle<QueueSelectedEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly CurrentSelectedQueueContext _currentSelectedQueueContext;
        private readonly ObservableCollection<DetailsView> _detailsViews = new ObservableCollection<DetailsView>();

        public ShellViewModel(IEventAggregator eventAggregator, CurrentSelectedQueueContext currentSelectedQueueContext)
        {
            _eventAggregator = eventAggregator;
            _currentSelectedQueueContext = currentSelectedQueueContext;
            _eventAggregator.Subscribe(this);
        }

        public ObservableCollection<DetailsView> DetailsViews
        {
            get { return _detailsViews; }
        }

        public void Handle(QueueSelectedEvent queueSelectedEvent)
        {
            _currentSelectedQueueContext.CurrentSelectedMessageQueue = queueSelectedEvent.MessageQueue;
            var existingViewForQueue = DetailsViews.SingleOrDefault(d => d.Title == queueSelectedEvent.MessageQueue.QueueName);
            if (existingViewForQueue != null)
            {
                existingViewForQueue.Activate();
            }
            else
            {
                var newDetailsView = new DetailsView();
                DetailsViews.Add(newDetailsView);
                NotifyOfPropertyChange(() => DetailsViews);
                newDetailsView.Activate();
            }
        }
    }
}
