namespace Presenters
{
    using System.ComponentModel;
    using Models;

    public abstract class PresenterBaseClass<T> where T : ModelBaseClass
    {
        private T _model;

        public T Model
        {
            get { return _model; }
            set
            {
                T previousModel = null;

                if (_model == value) { return; }

                if (_model != null)
                {
                    _model.PropertyChanged -= Model_PropertyChanged;
                    previousModel = _model;
                }

                _model = value;
                _model.PropertyChanged += Model_PropertyChanged;

                ModelSetInitialization(previousModel);
            }
        }
        protected abstract void Model_PropertyChanged(object sender, PropertyChangedEventArgs e);

        protected virtual void ModelSetInitialization(T previousModel)
        {

        }
    }
}