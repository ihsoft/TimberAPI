using Timberborn.AssetSystem;

namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class UiPresetFactory
    {
        private readonly ButtonPresetFactory _buttonPresetFactory;

        private readonly TogglePresetFactory _togglePresetFactory;

        private readonly ScrollPresetFactory _scrollPresetFactory;
        
        private readonly LabelPresetFactory _labelPresetFactory;
        
        private readonly SliderPresetFactory _sliderPresetFactory;

        public UiPresetFactory(ComponentBuilder componentBuilder, IResourceAssetLoader resourceAssetLoader)
        {
            _buttonPresetFactory = new ButtonPresetFactory(componentBuilder);
            _togglePresetFactory = new TogglePresetFactory(componentBuilder);
            _labelPresetFactory = new LabelPresetFactory(componentBuilder);
            _sliderPresetFactory = new SliderPresetFactory(componentBuilder, resourceAssetLoader);
            _scrollPresetFactory = new ScrollPresetFactory(componentBuilder, resourceAssetLoader);
        }
        
        public ButtonPresetFactory Buttons()
        {
            return _buttonPresetFactory;
        }
        
        public TogglePresetFactory Toggles()
        {
            return _togglePresetFactory;
        }
        
        public ScrollPresetFactory ScrollViews()
        {
            return _scrollPresetFactory;
        }
        
        public LabelPresetFactory Labels()
        {
            return _labelPresetFactory;
        }
        
        public SliderPresetFactory Sliders()
        {
            return _sliderPresetFactory;
        }
    }
}