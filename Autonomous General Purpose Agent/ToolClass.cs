
public class ToolClass
{
    public static async Task<List<Tool>> AllTools(ToolPermissionManager _toolPermissions, bool outputPreview = false, bool FullAccess = true)
    {
        List<Tool> toolList = new();

        var toolListPreview = new StringBuilder();

        var allToolsAllowed = new[] {
                 "get_open_windows",
                 "get_menu_structure",
                 "get_window_elements",
                 "click_element",
                 "type_text",
                 "capture_element",
                 "capture_window_with_highlights",
                 "describe_element",
                 "set_slider_value",
                 "select_list_item",
                 "scroll_element",
                 "set_element_value",
                 "window_action",
                 "move_resize_window",
                 "double_click_element",
                 "right_click_element",
                 "list_ui_maps",
                 "get_ui_map_info",
                 "clear_ui_map",
                 "start_window_monitoring",
                 "stop_window_monitoring",
                 "get_window_changes",
                 "get_window_monitor_stats",
                 "mark_window_changes_read",
                 "start_webpage_monitoring",
                 "stop_webpage_monitoring",
                 "monitor_element",
                 "stop_monitoring_element",
                 "get_webpage_monitor_stats",
                 "refresh_element_now",
                "screen_capture",
                "memory_tool",
                "list_editors",
                "focus_editor",
                "compile_code",
                "create_app_plan",
                "create_editors",
                "generate_python_code",
                "close_editor",
                "save_file",
                "open_file",
                "edit_code",
                "create_venv",
                "install_pip_packages",
                "run_code",
                "list_files",
                "read_file",
                "manage_files",
                "get_full_content",
                "script_pwr",
                "run_command_script",
                "file_exists",
                "save_project",
                "list_saved_projects",
                "load_project",
                "research",
                "request_verification",
                "request_agent_creation",
                "web_search_server",
                "keyboard_and_mouse",
                "identify_elements",
                "confirm_elements",
                "get_open_windows"
            };

        #region 1 get_open_windows

        var getOpenWindows = new ToolTransformerBuilder()
            .AddToolName("get_open_windows")
            .AddDescription("Retrieves a list open windows.")
            //.AddConstraint("Ensure that the request is made in the context of a valid user session",
            //               "Unauthorized requests will be denied")
            //.AddKeyWords("Workspace Management", "Resource Monitoring", "Editor Control")
            //.AddInstructionHeader("Editor Retrieval Guidelines")
            //.AddInstructions("Use this tool to get an overview of all open editors")
            //.AddInstructions("Verify the user session before making requests")
            .AddNestedObject(
                objectName: "get_open_windows_params",
                objectDescription: "Reguest for a list of open windows.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "name",
                fieldType: "string",
                fieldDescription: "Specifies the name of the window to retrieve, if known. Otherwise, all open windows will be returned.",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(getOpenWindows);

        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getOpenWindows));
        _toolPermissions.RegisterTool(toolName: "get_open_windows", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 1 get_open_windows

        #region 2 get_menu_structure

        var getMenuStructure = new ToolTransformerBuilder()
            .AddToolName("get_menu_structure")
            .AddDescription("Retrieves the menu structure for a window. Can search for specific menu items by path.")
            .AddNestedObject(
                objectName: "get_menu_structure_params",
                objectDescription: "Request for a window's menu structure.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "window_name",
                fieldType: "string",
                fieldDescription: "The name of the window to retrieve menus from (e.g., 'notepad', 'visual studio').",
                isRequired: true
            )
            .AddProperty(
                fieldName: "menu_path",
                fieldType: "array",
                fieldDescription: "Optional menu path to search for specific items (e.g., ['View', 'Zoom', 'Zoom In']). If omitted, returns all menus.",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(getMenuStructure);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getMenuStructure));
        _toolPermissions.RegisterTool(toolName: "get_menu_structure", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 2 get_menu_structure

        #region 3 get_window_elements

        var getWindowElements = new ToolTransformerBuilder()
            .AddToolName("get_window_elements")
            .AddDescription("Retrieves all interactive UI elements for a window with persistent element IDs (buttons, inputs, etc.).")
            .AddNestedObject(
                objectName: "get_window_elements_params",
                objectDescription: "Request for a window's UI element tree.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "window_id",
                fieldType: "string",
                fieldDescription: "The ID of the window to retrieve elements from.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "depth",
                fieldType: "integer",
                fieldDescription: "How many levels deep to explore the UI tree. Default: 2. Use 1 for top-level only, 3+ for deep trees.",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(getWindowElements);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getWindowElements));
        _toolPermissions.RegisterTool(toolName: "get_window_elements", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 3 get_window_elements

        #region 4 click_element

        var clickElement = new ToolTransformerBuilder()
            .AddToolName("click_element")
            .AddDescription("Clicks a UI element by its persistent element ID (obtained from get_window_elements or get_menu_structure).")
            .AddNestedObject(
                objectName: "click_element_params",
                objectDescription: "Click operation by element ID.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID to click (from get_window_elements or get_menu_structure).",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(clickElement);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(clickElement));
        _toolPermissions.RegisterTool(toolName: "click_element", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 4 click_element

        #region 5 type_text

        var typeText = new ToolTransformerBuilder()
            .AddToolName("type_text")
            .AddDescription("Types text into a UI element by its element ID. The element must support text input (Edit, Document, etc.). Optionally press Enter after typing for form submissions.")
            .AddNestedObject(
                objectName: "type_text_params",
                objectDescription: "Type text into an element.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID to type into (must be a text input element).",
                isRequired: true
            )
            .AddProperty(
                fieldName: "text",
                fieldType: "string",
                fieldDescription: "The text to type into the element.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "submit",
                fieldType: "boolean",
                fieldDescription: "If true, press Enter after typing to submit the text (useful for search boxes and forms). Default is false.",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(typeText);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(typeText));
        _toolPermissions.RegisterTool(toolName: "type_text", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 5 type_text

        #region 6 capture_element

        var captureElement = new ToolTransformerBuilder()
            .AddToolName("capture_element")
            .AddDescription("Captures a screenshot of a specific UI element by its element ID for visual confirmation.")
            .AddNestedObject(
                objectName: "capture_element_params",
                objectDescription: "Capture screenshot of an element.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID to capture.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "highlight",
                fieldType: "boolean",
                fieldDescription: "Whether to highlight the element with a border in the screenshot. Default: true.",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(captureElement);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(captureElement));
        _toolPermissions.RegisterTool(toolName: "capture_element", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 6 capture_element

        #region 6.5 capture_window_with_highlights

        var captureWindowWithHighlights = new ToolTransformerBuilder()
            .AddToolName("capture_window_with_highlights")
            .AddDescription("Captures a screenshot of a window with specified elements highlighted and labeled with their IDs for visual verification.")
            .AddNestedObject(
                objectName: "capture_window_with_highlights_params",
                objectDescription: "Capture window with element highlights.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "window_name",
                fieldType: "string",
                fieldDescription: "The name of the window to capture (e.g., 'notepad', 'calculator').",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_ids",
                fieldType: "array",
                fieldDescription: "Array of element IDs to highlight and label in the screenshot.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(captureWindowWithHighlights);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(captureWindowWithHighlights));
        _toolPermissions.RegisterTool(toolName: "capture_window_with_highlights", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 6.5 capture_window_with_highlights

        #region 6.6 describe_element

        var describeElement = new ToolTransformerBuilder()
            .AddToolName("describe_element")
            .AddDescription("Captures an element and gets a text description from LMStudio vision model. Saves main AI tokens by using local vision model for UI element descriptions.")
            .AddNestedObject(
                objectName: "describe_element_params",
                objectDescription: "Describe element using LMStudio vision.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID to capture and describe.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "prompt",
                fieldType: "string",
                fieldDescription: "Optional custom prompt for the vision model. Default: 'Describe the content of this image.'",
                isRequired: false
            )
            .AddProperty(
                fieldName: "lmstudio_endpoint",
                fieldType: "string",
                fieldDescription: "Optional LMStudio endpoint URL. Default: 'http://localhost:1234/v1/chat/completions'",
                isRequired: false
            )
            .AddProperty(
                fieldName: "model",
                fieldType: "string",
                fieldDescription: "Optional model name. Default: 'describe'",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(describeElement);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(describeElement));
        _toolPermissions.RegisterTool(toolName: "describe_element", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 6.6 describe_element

        #region 7 set_slider_value

        var setSliderValue = new ToolTransformerBuilder()
            .AddToolName("set_slider_value")
            .AddDescription("Sets a slider or progress bar to a specific value. The value will be automatically clamped to the slider's minimum and maximum range.")
            .AddNestedObject(
                objectName: "set_slider_value_params",
                objectDescription: "Set slider value operation.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID of the slider (from get_window_elements).",
                isRequired: true
            )
            .AddProperty(
                fieldName: "value",
                fieldType: "number",
                fieldDescription: "The value to set (will be clamped to slider's min/max range).",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(setSliderValue);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(setSliderValue));
        _toolPermissions.RegisterTool(toolName: "set_slider_value", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 7 set_slider_value

        #region 8 select_list_item

        var selectListItem = new ToolTransformerBuilder()
            .AddToolName("select_list_item")
            .AddDescription("Selects a list item, desktop icon, radio button, or other selectable element. For single-select controls, this deselects any previously selected items. For multi-select lists, use with shift/ctrl modifiers via keyboard_and_mouse tool.")
            .AddNestedObject(
                objectName: "select_list_item_params",
                objectDescription: "Select list item operation.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID to select (works for list items, icons, radio buttons, etc.).",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(selectListItem);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(selectListItem));
        _toolPermissions.RegisterTool(toolName: "select_list_item", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 8 select_list_item

        #region 9 scroll_element

        var scrollElement = new ToolTransformerBuilder()
            .AddToolName("scroll_element")
            .AddDescription("Scrolls an element vertically or horizontally by a specified amount.")
            .AddNestedObject(
                objectName: "scroll_element_params",
                objectDescription: "Scroll operation parameters.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID to scroll (must support scrolling).",
                isRequired: true
            )
            .AddProperty(
                fieldName: "direction",
                fieldType: "string",
                fieldDescription: "Direction to scroll: 'up', 'down', 'left', 'right', 'pageup', 'pagedown'.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "amount",
                fieldType: "integer",
                fieldDescription: "Number of times to scroll in the direction. Default: 1.",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(scrollElement);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(scrollElement));
        _toolPermissions.RegisterTool(toolName: "scroll_element", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 9 scroll_element

        #region 10 set_element_value

        var setElementValue = new ToolTransformerBuilder()
            .AddToolName("set_element_value")
            .AddDescription("Sets the value of an element directly. Works with spinners (numeric up/down controls), numeric input fields, combo boxes/dropdowns, and other value-supporting controls. Use this instead of typing when the control supports direct value setting.")
            .AddNestedObject(
                objectName: "set_element_value_params",
                objectDescription: "Set element value operation.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID to set value for.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "value",
                fieldType: "string",
                fieldDescription: "The value to set.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(setElementValue);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(setElementValue));
        _toolPermissions.RegisterTool(toolName: "set_element_value", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 10 set_element_value

        #region 11 window_action

        var windowAction = new ToolTransformerBuilder()
            .AddToolName("window_action")
            .AddDescription("Performs window operations: minimize, maximize, restore, or close.")
            .AddNestedObject(
                objectName: "window_action_params",
                objectDescription: "Window action operation.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The window element ID (usually the top-level window).",
                isRequired: true
            )
            .AddProperty(
                fieldName: "action",
                fieldType: "string",
                fieldDescription: "Action to perform: 'minimize', 'maximize', 'restore', 'normal', or 'close'.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(windowAction);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(windowAction));
        _toolPermissions.RegisterTool(toolName: "window_action", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 11 window_action

        #region 12 move_resize_window

        var moveResizeWindow = new ToolTransformerBuilder()
            .AddToolName("move_resize_window")
            .AddDescription("Moves and/or resizes a window. Can move only (x,y), resize only (width,height), or do both simultaneously. All parameters are optional but at least one pair (x+y or width+height) should be provided.")
            .AddNestedObject(
                objectName: "move_resize_window_params",
                objectDescription: "Move/resize window operation.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The window element ID.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "x",
                fieldType: "integer",
                fieldDescription: "X coordinate for window position (optional, used with y).",
                isRequired: false
            )
            .AddProperty(
                fieldName: "y",
                fieldType: "integer",
                fieldDescription: "Y coordinate for window position (optional, used with x).",
                isRequired: false
            )
            .AddProperty(
                fieldName: "width",
                fieldType: "integer",
                fieldDescription: "Width to resize window to (optional, used with height).",
                isRequired: false
            )
            .AddProperty(
                fieldName: "height",
                fieldType: "integer",
                fieldDescription: "Height to resize window to (optional, used with width).",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(moveResizeWindow);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(moveResizeWindow));
        _toolPermissions.RegisterTool(toolName: "move_resize_window", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 12 move_resize_window

        #region 13 double_click_element

        var doubleClickElement = new ToolTransformerBuilder()
            .AddToolName("double_click_element")
            .AddDescription("Double-clicks an element (for opening files, folders, desktop icons, etc.).")
            .AddNestedObject(
                objectName: "double_click_element_params",
                objectDescription: "Double-click operation.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID to double-click.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(doubleClickElement);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(doubleClickElement));
        _toolPermissions.RegisterTool(toolName: "double_click_element", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 13 double_click_element

        #region 14 right_click_element

        var rightClickElement = new ToolTransformerBuilder()
            .AddToolName("right_click_element")
            .AddDescription("Right-clicks an element to open context menu.")
            .AddNestedObject(
                objectName: "right_click_element_params",
                objectDescription: "Right-click operation.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "element_id",
                fieldType: "integer",
                fieldDescription: "The element ID to right-click.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(rightClickElement);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(rightClickElement));
        _toolPermissions.RegisterTool(toolName: "right_click_element", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 14 right_click_element

        #region 15 list_ui_maps

        var listUiMaps = new ToolTransformerBuilder()
            .AddToolName("list_ui_maps")
            .AddDescription("Lists all saved UI maps. Shows which windows have persistent element ID mappings.")
            .AddNestedObject(
                objectName: "list_ui_maps_params",
                objectDescription: "Request to list all saved UI maps.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(listUiMaps);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(listUiMaps));
        _toolPermissions.RegisterTool(toolName: "list_ui_maps", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 15 list_ui_maps

        #region 16 get_ui_map_info

        var getUiMapInfo = new ToolTransformerBuilder()
            .AddToolName("get_ui_map_info")
            .AddDescription("Gets detailed information about a saved UI map for a window.")
            .AddNestedObject(
                objectName: "get_ui_map_info_params",
                objectDescription: "Request for UI map information.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "window_name",
                fieldType: "string",
                fieldDescription: "The name of the window to get UI map info for.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(getUiMapInfo);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getUiMapInfo));
        _toolPermissions.RegisterTool(toolName: "get_ui_map_info", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 16 get_ui_map_info

        #region 17 clear_ui_map

        var clearUiMap = new ToolTransformerBuilder()
            .AddToolName("clear_ui_map")
            .AddDescription("Deletes a saved UI map for a window. Forces a fresh scan on next access with new element IDs.")
            .AddNestedObject(
                objectName: "clear_ui_map_params",
                objectDescription: "Request to delete a UI map.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "window_name",
                fieldType: "string",
                fieldDescription: "The name of the window whose UI map should be deleted.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(clearUiMap);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(clearUiMap));
        _toolPermissions.RegisterTool(toolName: "clear_ui_map", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 17 clear_ui_map

        #region 18 start_window_monitoring

        var startWindowMonitoring = new ToolTransformerBuilder()
            .AddToolName("start_window_monitoring")
            .AddDescription("Starts automatic background monitoring of window changes. The system will continuously track new windows appearing, windows closing, window title changes, and window content changes. Once started, use get_window_changes to query what changed.")
            .AddNestedObject(
                objectName: "start_window_monitoring_params",
                objectDescription: "Request to start window monitoring.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "polling_interval_ms",
                fieldType: "integer",
                fieldDescription: "How often to check for changes in milliseconds. Default: 1000 (1 second). Minimum: 100, Maximum: 10000.",
                isRequired: false
            )
            .AddProperty(
                fieldName: "monitor_new_windows",
                fieldType: "boolean",
                fieldDescription: "Track new windows appearing. Default: true.",
                isRequired: false
            )
            .AddProperty(
                fieldName: "monitor_closed_windows",
                fieldType: "boolean",
                fieldDescription: "Track windows closing. Default: true.",
                isRequired: false
            )
            .AddProperty(
                fieldName: "monitor_title_changes",
                fieldType: "boolean",
                fieldDescription: "Track window title changes. Default: true.",
                isRequired: false
            )
            .AddProperty(
                fieldName: "monitor_children_changes",
                fieldType: "boolean",
                fieldDescription: "Track changes in window content/children. Default: true.",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(startWindowMonitoring);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(startWindowMonitoring));
        _toolPermissions.RegisterTool(toolName: "start_window_monitoring", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 18 start_window_monitoring

        #region 19 stop_window_monitoring

        var stopWindowMonitoring = new ToolTransformerBuilder()
            .AddToolName("stop_window_monitoring")
            .AddDescription("Stops automatic window change monitoring. Previously detected changes remain available until cleared.")
            .AddNestedObject(
                objectName: "stop_window_monitoring_params",
                objectDescription: "Request to stop window monitoring.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(stopWindowMonitoring);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(stopWindowMonitoring));
        _toolPermissions.RegisterTool(toolName: "stop_window_monitoring", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 19 stop_window_monitoring

        #region 20 get_window_changes

        var getWindowChanges = new ToolTransformerBuilder()
            .AddToolName("get_window_changes")
            .AddDescription("Gets detected window changes. Returns list of change events with details about what changed (new windows, closed windows, title changes, content changes). Can filter by type or time range.")
            .AddNestedObject(
                objectName: "get_window_changes_params",
                objectDescription: "Request for window change information.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "unread_only",
                fieldType: "boolean",
                fieldDescription: "Only return unread changes. Default: true.",
                isRequired: false
            )
            .AddProperty(
                fieldName: "change_type",
                fieldType: "string",
                fieldDescription: "Filter by change type: WindowOpened, WindowClosed, WindowTitleChanged, ChildrenChanged, WindowGeometryChanged, WindowFocused, WindowUnfocused. If not specified, returns all types.",
                isRequired: false
            )
            .AddProperty(
                fieldName: "since_minutes_ago",
                fieldType: "integer",
                fieldDescription: "Only return changes from the last N minutes. If not specified, returns all changes matching other filters.",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(getWindowChanges);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getWindowChanges));
        _toolPermissions.RegisterTool(toolName: "get_window_changes", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 20 get_window_changes

        #region 21 get_window_monitor_stats

        var getWindowMonitorStats = new ToolTransformerBuilder()
            .AddToolName("get_window_monitor_stats")
            .AddDescription("Gets statistics about window monitoring: total events, unread events, current window count, monitoring status, breakdown by event type.")
            .AddNestedObject(
                objectName: "get_window_monitor_stats_params",
                objectDescription: "Request for monitoring statistics.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(getWindowMonitorStats);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getWindowMonitorStats));
        _toolPermissions.RegisterTool(toolName: "get_window_monitor_stats", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 21 get_window_monitor_stats

        #region 22 mark_window_changes_read

        var markWindowChangesRead = new ToolTransformerBuilder()
            .AddToolName("mark_window_changes_read")
            .AddDescription("Marks window change events as read. Can mark specific events by ID or all events.")
            .AddNestedObject(
                objectName: "mark_window_changes_read_params",
                objectDescription: "Request to mark changes as read.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "event_ids",
                fieldType: "array",
                fieldDescription: "Array of event IDs to mark as read. If not specified or empty, marks ALL events as read.",
                isRequired: false
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(markWindowChangesRead);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(markWindowChangesRead));
        _toolPermissions.RegisterTool(toolName: "mark_window_changes_read", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 22 mark_window_changes_read

        #region 23 create_app_plan

        var appPlanTool = new ToolTransformerBuilder()
             .AddToolName("create_app_plan")
             .AddDescription("Creates a comprehensive application blueprint based on user requirements. This tool analyzes project specifications to generate a structured development plan containing all necessary components, dependencies, and implementation steps required for successful application development.")
             .AddConstraint("Should only be used at the beginning of the development lifecycle",
                            "Requires detailed project specifications to generate comprehensive plans")

             .AddKeyWords("Development Planning", "Application Architecture", "Requirements Analysis", "Make a plan")

             .AddInstructionHeader("Application Planning Guidelines")
             .AddInstructions("Provide a detailed project description with specific requirements")
             .AddInstructions("Complex applications and/or logic should be modular in nature, allow for modifications of individual components such as modules and class files")
             .AddInstructions("Review the generated plan before proceeding to implementation")
             .AddInstructions("Use the output as input for subsequent code generation tools")
             .AddNestedObject(
                 objectName: "app_plan",
                 objectDescription: "Core planning specifications that define the application structure, requirements, and implementation pathway. Contains essential parameters needed to generate a comprehensive development blueprint.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "project_description",
                 fieldType: "string",
                 fieldDescription: "Detailed explanation of the application's core functionality and purpose. Captures essential requirements from the user's request, serving as the foundation for all generated components.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "requirements",
                 fieldType: "array",
                 fieldDescription: "Prioritized list of functional requirements that the application must fulfill. Each requirement should be specific, measurable, and directly derived from the project description.",
                 isRequired: true,
                 items: new Dictionary<string, string> { { "type", "string" } }
             )
             .AddProperty(
                 fieldName: "implementation_steps",
                 fieldType: "array",
                 fieldDescription: "Sequential development workflow defining the precise order of implementation tasks. Each step should be granular, actionable, and linked to specific requirements.",
                 isRequired: true,
                 items: new Dictionary<string, string> { { "type", "string" } }
             )
             .AddProperty(
                 fieldName: "components",
                 fieldType: "array",
                 fieldDescription: "Architectural components and modules that comprise the application structure. Identifies all discrete functional units and their relationships within the system architecture.",
                 isRequired: true,
                 items: new Dictionary<string, string> { { "type", "string" } }
             )
             .AddProperty(
                 fieldName: "data_model",
                 fieldType: "string",
                 fieldDescription: "Structured representation of data entities, attributes, and relationships required by the application. Defines the fundamental data organization pattern."
             )
             .AddProperty(
                 fieldName: "features",
                 fieldType: "array",
                 fieldDescription: "Distinct user-facing capabilities that provide value within the application. Each feature should address specific user needs identified in the project description.",
                 isRequired: true,
                 items: new Dictionary<string, string> { { "type", "string" } }
             )
             .AddProperty(
                 fieldName: "technical_specs",
                 fieldType: "array",
                 fieldDescription: "Technical implementation details including programming languages, frameworks, libraries, and architectural patterns. Provides the technological foundation for development decisions.",
                 isRequired: true,
                 items: new Dictionary<string, string> { { "type", "string" } }
             )
             .AddProperty(
                 fieldName: "file_structure",
                 fieldType: "string",
                 fieldDescription: "Organized hierarchy of project files and directories that follows best practices for the selected technology stack. Provides a blueprint for code organization.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "file_description",
                 fieldType: "array",
                 fieldDescription: "Detailed documentation of each file's purpose, responsibilities, and relationships within the application architecture. Explains how each file contributes to the overall system functionality.",
                 isRequired: true,
                 items: new Dictionary<string, string> { { "type", "string" } }
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(appPlanTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(appPlanTool));
        _toolPermissions.RegisterTool(toolName: "create_app_plan", canInitiateToolChain: true, FullAccess ? allToolsAllowed : new[] {
"create_app_plan",
"edit_code",
"compile_code",
"generate_python_code",
"install_pip_packages"
});

        #endregion 23 create_app_plan

        #region 24 create_editors

        var createDynamicIdeTool = new ToolTransformerBuilder()
            .AddToolName("create_editors")
            .AddDescription("Establishes dedicated code editing environments for development tasks. This tool creates configurable Editor windows for code manipulation and text editing, enabling isolated work on specific application components.")
            .AddConstraint("Use only when automatic Editor creation via generate_python_code is insufficient",
                           "Each Editor requires unique identification to prevent workspace conflicts")
            .AddKeyWords("Code Editing", "Development Environment", "Workspace Management")
            .AddInstructionHeader("Editor Creation Guidelines")
            .AddInstructions("Create separate editors for logically distinct components")
            .AddInstructions("Ensure each editor has a descriptive identifier reflecting its purpose")
            .AddInstructions("Configure appropriate syntax highlighting for the target file type")
            .AddNestedObject(
               objectName: "create_editors",
               objectDescription: "Configuration parameters for creating one or more Editor instances. Each instance provides an isolated environment for code development with specific settings.",
               isRequired: true,
               isArray: true
            )
            .AddProperty(
                fieldName: "editor_id",
                fieldType: "string",
                fieldDescription: "same as the file_name including its extension.",
                isRequired: true
            )
            //.AddProperty(
            //    fieldName: "is_focused",
            //    fieldType: "boolean",
            //    fieldDescription: "Determines whether this Editor becomes the active window after creation. When true, brings the Editor to the foreground for immediate interaction."
            //)
            //.AddProperty(
            //    fieldName: "Description",
            //    fieldType: "string",
            //    fieldDescription: "Functional overview describing the purpose and content of this Editor instance within the development workflow."
            //)
            .AddProperty(
                fieldName: "file_name",
                fieldType: "string",
                fieldDescription: "Target filename for content saved from this Editor. For Python projects, use 'main.py' as the primary entry point or for single-file applications.",
                isRequired: true
            )
            //.AddProperty(
            //    fieldName: "syntax_type",
            //    fieldType: "string",
            //    fieldDescription: "Language-specific syntax highlighting mode that enhances code readability. Common values include 'python', 'javascript', 'html', or 'text'.",
            //    isRequired: true
            //)
            //.AddProperty(
            //    fieldName: "tool_use_log",
            //    fieldType: "string",
            //    fieldDescription: "System logging information capturing Editor creation details for operational tracking and debugging purposes."
            //)
            //.AddProperty(
            //    fieldName: "chat_message",
            //    fieldType: "string",
            //    fieldDescription: "User-facing notification message explaining the Editor creation outcome and next steps in the workflow."
            //)
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(createDynamicIdeTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(createDynamicIdeTool));

        _toolPermissions.RegisterTool(toolName: "create_editors", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
"compile_code",
"close_editor",
"edit_code",
"focus_editor",
"generate_python_code",
"list_editors",
"memory_tool",
"screen_capture"
});

        #endregion 24 create_editors

        #region 25 generate_python_code

        var pythonGenerateTool = new ToolTransformerBuilder()
             .AddToolName("generate_python_code")

             .AddDescription("Creates a comprehensive application blueprint based on user requirements. This tool analyzes project specifications to generate a structured development plan containing all necessary components, dependencies, and implementation steps required for successful application development.")

             .AddConstraint("Should only be used at the beginning of the development lifecycle",
                            "Requires detailed project specifications to generate comprehensive plans")

             //.AddKeyWords("Development Planning", "Application Architecture", "Requirements Analysis", "Make a plan")

             .AddInstructionHeader("Application Planning Guidelines")
             .AddInstructions("Provide a detailed project description with specific requirements")
             .AddInstructions("Complex applications and/or logic should be modular in nature to allow for modifications of individual components such as modules and class files")
             .AddInstructions("Review the generated plan before proceeding to implementation")
             .AddInstructions("Use the output as input for subsequent code generation tools")

             .AddNestedObject(
                 objectName: "app_plan",
                 objectDescription: "Core planning specifications that define the application structure, requirements, and implementation pathway. Contains essential parameters needed to generate a comprehensive development blueprint.",
                 isRequired: true
                 )
                 .AddProperty(
                     fieldName: "project_description",
                     fieldType: "string",
                     fieldDescription: "Detailed explanation of the application's core functionality and purpose. Captures essential requirements from the user's request, serving as the foundation for all generated components.",
                     isRequired: true
                 )
                 .AddProperty(
                     fieldName: "requirements",
                     fieldType: "array",
                     fieldDescription: "Prioritized list of functional requirements that the application must fulfill. Each requirement should be specific, measurable, and directly derived from the project description.",
                     isRequired: true,
                     items: new Dictionary<string, string> { { "type", "string" } }
                 )
                 .AddProperty(
                     fieldName: "implementation_steps",
                     fieldType: "array",
                     fieldDescription: "Sequential development workflow defining the precise order of implementation tasks. Each step should be granular, actionable, and linked to specific requirements.",
                     isRequired: true,
                     items: new Dictionary<string, string> { { "type", "string" } }
                 )
                 .AddProperty(
                     fieldName: "components",
                     fieldType: "array",
                     fieldDescription: "Architectural components and modules that comprise the application structure. Identifies all discrete functional units and their relationships within the system architecture.",
                     isRequired: true,
                     items: new Dictionary<string, string> { { "type", "string" } }
                 )
                 .AddProperty(
                     fieldName: "data_model",
                     fieldType: "string",
                     fieldDescription: "Structured representation of data entities, attributes, and relationships required by the application. Defines the fundamental data organization pattern."
                 )
                 .AddProperty(
                     fieldName: "features",
                     fieldType: "array",
                     fieldDescription: "Distinct user-facing capabilities that provide value within the application. Each feature should address specific user needs identified in the project description.",
                     isRequired: true,
                     items: new Dictionary<string, string> { { "type", "string" } }
                 )
                 .AddProperty(
                     fieldName: "technical_specs",
                     fieldType: "array",
                     fieldDescription: "Technical implementation details including programming languages, frameworks, libraries, and architectural patterns. Provides the technological foundation for development decisions.",
                     isRequired: true,
                     items: new Dictionary<string, string> { { "type", "string" } }
                 )
                 .AddProperty(
                     fieldName: "file_structure",
                     fieldType: "string",
                     fieldDescription: "Organized hierarchy of project files and directories that follows best practices for the selected technology stack. Provides a blueprint for code organization.",
                     isRequired: true
                 )
                 .AddProperty(
                     fieldName: "file_description",
                     fieldType: "array",
                     fieldDescription: "Detailed documentation of each file's purpose, responsibilities, and relationships within the application architecture. Explains how each file contributes to the overall system functionality.",
                     isRequired: true,
                     items: new Dictionary<string, string> { { "type", "string" } }
                 )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(pythonGenerateTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(pythonGenerateTool));
        _toolPermissions.RegisterTool(toolName: "generate_python_code", canInitiateToolChain: true, FullAccess ? allToolsAllowed : new[] {
"create_app_plan",
"edit_code",
"compile_code",
"generate_python_code",
"install_pip_packages"
});

        #endregion 25 generate_python_code

        #region 26 close_editor

        var removeDynamicIdeTool = new ToolTransformerBuilder()
             .AddToolName("close_editor")
             .AddDescription("Terminates and removes Editor instances that are no longer needed. This tool helps manage system resources and maintain workspace organization by closing specified Editor windows.")
             .AddConstraint("Verify that any important content has been saved before closing",
                            "Editor instances cannot be recovered after closing")
             .AddKeyWords("Workspace Management", "Resource Optimization", "Editor Control")
             .AddInstructionHeader("Editor Closure Guidelines")
             .AddInstructions("Save all important content before closing editors")
             .AddInstructions("Verify the correct editor ID to prevent accidental closure")
             .AddNestedObject(
                 objectName: "editor_config",
                 objectDescription: "Configuration parameters that identify the specific Editor instance to be terminated. Controls precise targeting of cleanup operations.",
                 isRequired: true
                 )
                 .AddProperty(
                     fieldName: "editor_id",
                     fieldType: "string",
                     fieldDescription: "Unique identifier of the target Editor instance to close. Must exactly match the ID used during the Editor's creation.",
                     isRequired: true
                 )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(removeDynamicIdeTool);

        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(removeDynamicIdeTool));
        _toolPermissions.RegisterTool(toolName: "close_editor", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
"close_editor",
"create_editors",
"compile_code",
"create_app_plan",
"create_venv",
"edit_code",
"file_exists",
"focus_editor",
"generate_python_code",
"install_pip_packages",
"list_editors",
"list_files",
"list_saved_projects",
"load_project",
"memory_tool",
"open_file",
"read_file",
"save_file",
"screen_capture"
});

        #endregion 26 close_editor

        #region 27 list_editors

        var getDynamicIdeStatesTool = new ToolTransformerBuilder()
             .AddToolName("list_editors")
             .AddDescription("Inventories active Editor instances and their contents. This tool provides visibility into the current development environment state, supporting workspace management and content inspection.")
             .AddConstraint("Content retrieval may impact performance for large files",
                            "Filter queries appropriately to focus on relevant editors")
             .AddKeyWords("Environment Status", "Content Inspection", "Workspace Inventory")
             .AddInstructionHeader("Editor Listing Guidelines")
             .AddInstructions("Use specific editor IDs when querying individual instances")
             .AddInstructions("Request content previews for quick inspection without full content loads")
             .AddNestedObject(
                 objectName: "list_editors",
                 objectDescription: "Query parameters that control which Editor instances are included in the results and what level of content detail is provided. Enables targeted information retrieval.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "query_type",
                 fieldType: "string",
                 fieldDescription: "Selection mode that determines which Editor instances are included in the results. Options include 'all' (every instance), 'active' (only currently focused), or 'specific' (single targeted instance).",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "editor_id",
                 fieldType: "string",
                 fieldDescription: "Target identifier for selective queries when using 'specific' query type. Must match an existing Editor ID exactly to return results.",
                 isRequired: false
             )
             .AddProperty(
                 fieldName: "included_content",
                 fieldType: "string",
                 fieldDescription: "Content retrieval mode that controls how much code is returned with the results. Options include 'all' (full content), 'preview' (truncated sample), or 'none' (metadata only).",
                 isRequired: true
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(getDynamicIdeStatesTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getDynamicIdeStatesTool));
        _toolPermissions.RegisterTool(toolName: "list_editors", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
"create_app_plan",
"create_editors",
"close_editor",
"compile_code",
"edit_code",
"focus_editor",
"file_exists",
"generate_python_code",
"get_full_content",
"install_pip_packages",
"manage_files",
"memory_tool",
"open_file",
"run_command_script",
"read_file",
"save_file",
"screen_capture",
"script_pwr",
"save_project",
"list_saved_projects",
"load_project",
"list_files",
"list_editors",
});

        #endregion 27 list_editors

        #region 28 focus_editor

        var activateIdeTool = new ToolTransformerBuilder()
             .AddToolName("focus_editor")
             .AddDescription("Activates a specific Editor instance as the primary workspace. This tool redirects system focus to the designated Editor window, making it the target for subsequent operations and user interactions.")
             .AddConstraint("Target Editor must exist before focusing",
                            "Only one Editor can have focus at any given time")
             .AddKeyWords("Workspace Navigation", "Editor Activation", "Focus Control")
             .AddInstructionHeader("Editor Focus Guidelines")
             .AddInstructions("Verify the Editor ID exists before attempting to focus")
             .AddInstructions("Use focus operations to establish context before editing content")

             .AddNestedObject(
                 objectName: "editor_config",
                 objectDescription: "Focus operation parameters that identify the target Editor and control notification behavior. Determines which workspace becomes active.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "editor_id",
                 fieldType: "string",
                 fieldDescription: "Unique identifier of the Editor instance to activate. Must reference an existing Editor window in the current session."
             )
             .AddProperty(
                 fieldName: "tool_use_log",
                 fieldType: "string",
                 fieldDescription: "Operational record of the focus change for system logging purposes. Documents the context and reason for the workspace activation."
             )
             .AddProperty(
                 fieldName: "chat_message",
                 fieldType: "string",
                 fieldDescription: "User notification explaining the focus operation and current active workspace status. Provides workflow context for subsequent operations."
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(activateIdeTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(activateIdeTool));
        _toolPermissions.RegisterTool(toolName: "focus_editor", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
"compile_code",
"create_editors",
"edit_code",
"file_exists",
"focus_editor",
"generate_python_code",
"get_full_content",
"list_editors",
"memory_tool",
"open_file",
"save_file",
"screen_capture"
});

        #endregion 28 focus_editor

        #region 29 save_file

        var fileTextEditSaveTool = new ToolTransformerBuilder()
             .AddToolName("save_file")
             .AddDescription("Persists Editor content to the file system. This tool writes the current state of an Editor's content to a specified file location, ensuring work is preserved and accessible for subsequent operations.")
             .AddConstraint("Verify file structure exists before saving",
                            "Check for potential file conflicts or overwrites")
             .AddKeyWords("Data Persistence", "File System Operations", "Work Preservation")
             .AddInstructionHeader("File Saving Guidelines")
             .AddInstructions("Validate file paths before saving to prevent errors")
             .AddInstructions("Use consistent file naming patterns across the project")
             .AddNestedObject(
                 objectName: "editor_config",
                 objectDescription: "Save operation parameters that specify the source Editor and target file location. Controls where and how Editor content is persisted.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "editor_id",
                 fieldType: "string",
                 fieldDescription: "Unique identifier of the Editor instance containing the content to be saved. Must reference an active Editor in the current session.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "file_path",
                 fieldType: "string",
                 fieldDescription: "Full target path including directory structure and filename where the content will be written. Directories in the path must exist prior to saving.",
                 isRequired: true
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(fileTextEditSaveTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(fileTextEditSaveTool));
        _toolPermissions.RegisterTool(toolName: "save_file", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
"compile_code",
"close_editor",
"create_app_plan",
"edit_code",
"file_exists",
"focus_editor",
"generate_python_code",
"install_pip_packages",
"list_editors",
"list_files",
"list_saved_projects",
"load_project",
"manage_files",
"memory_tool",
"open_file",
"read_file",
"save_file",
"save_project",
"screen_capture"
});

        #endregion 29 save_file

        #region 30 open_file

        var loadFileToIdeTool = new ToolTransformerBuilder()
            .AddToolName("open_file")
            .AddDescription("Loads existing file content into an Editor instance. This tool retrieves content from the file system and displays it in a specified Editor window, enabling review and modification of existing files.")
            .AddConstraint("Target file must exist in the specified location",
                           "Ensure appropriate Editor type for the file format")
            .AddKeyWords("File Loading", "Content Retrieval", "Workspace Population")
            .AddInstructionHeader("File Opening Guidelines")
            .AddInstructions("Verify file existence before attempting to open")
            .AddInstructions("Match Editor configuration to the file type being opened")
            .AddNestedObject(
                objectName: "editor_config",
                objectDescription: "File loading parameters that specify the target Editor and source file. Controls how existing content is retrieved and displayed for editing.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "editor_id",
                fieldType: "string",
                fieldDescription: "Unique identifier for the Editor instance where the file will be displayed. If the specified Editor doesn't exist, a new one will be created automatically.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "file_name",
                fieldType: "string",
                fieldDescription: "Base name of the file to load, including its extension. Used for display purposes and Editor configuration.",
                isRequired: true
            )
            //.AddProperty(
            //    fieldName: "project_path",
            //    fieldType: "string",
            //    fieldDescription: "Directory path of the file to load."
            //)
            .AddProperty(
                fieldName: "file_path",
                fieldType: "string",
                fieldDescription: "Complete path to the source file, incorporating directory structure and filename. Must reference an existing file in the system.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(loadFileToIdeTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(loadFileToIdeTool));
        _toolPermissions.RegisterTool(toolName: "open_file", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
    "compile_code",
    "close_editor",
    "create_app_plan",
    "create_editors",
    "edit_code",
    "file_exists",
    "focus_editor",
    "generate_python_code",
    "get_full_content",
    "install_pip_packages",
    "list_editors",
    "list_files",
    "list_saved_projects",
    "load_project",
    "manage_files",
    "memory_tool",
    "open_file",
    "read_file",
    "run_command_script",
    "save_file",
    "save_project",
    "screen_capture",
    "script_pwr"
});

        #endregion 30 open_file

        #region 31 edit_code

        var codeModificationTool = new ToolTransformerBuilder()
            .AddToolName("edit_code")
            .AddDescription("Performs targeted modifications to code within an Editor. This tool enables precise changes to existing content through a variety of operations including insertion, deletion, and replacement at specified positions.")

            .AddConstraint(
            "Use the 'focus_editor' tool before editing",
            "editor_config must contain the id of the editor.",
            "Use the actual line numbers.",
            "Do NOT adjust for line number changes in the modification commands.",
            "Changes in line numbers and counts are adjusted automatically by the system.",
            "Verify line numbers before applying modifications",
            "Can't add content to an empty editor",
            "Line numbers must be greater than '0'")

            .AddKeyWords("Code Manipulation", "Content Editing", "Syntax Modification")

            .AddInstructionHeader("Code Editing Guidelines")
            .AddInstructions("Double-check line numbers to ensure accurate targeting")
            .AddInstructions("Use the 'focus_editor' tool before editing")

            .AddNestedObject("editor_config", "Target specification that identifies which Editor will receive modifications. Establishes the context for all editing operations.", isRequired: true)
            .AddProperty("editor_id", "string", "Unique identifier of the Editor instance containing the code to be modified. Must reference an active Editor with existing content.")
            .EndNestedObject()
            .EndObject()

            .AddNestedObject("modify_commands", "Sequence of editing operations to be applied to the target Editor. Each command represents a specific modification action with precise positioning. Line numbers must be greater than '0'", isRequired: true, isArray: true)
            .AddNestedObject("replace_range", "Replaces a range of lines in existing code")
                .AddProperty("start_line", "number", "Starting line number for replacement, start_line must be greater than '0'")
                .AddProperty("end_line", "number", "Ending line number for replacement.")
                .AddProperty("new_data", "string", "New code to replace the specified range.")
            .EndNestedObject()

            .AddNestedObject("replace_line", "Replaces a single line")
                .AddProperty("line_number", "number", "Line number to replace, line_number must be greater than '0'.")
                .AddProperty("new_data", "string", "New code for the specified line.")
            .EndNestedObject()
            .AddNestedObject("delete_range", "Deletes a range of lines")
                .AddProperty("start_line", "number", "Starting line number of the range to delete, start_line must be greater than '0'.")
                .AddProperty("end_line", "number", "Ending line number of the range to delete.")
            .EndNestedObject()
            .AddNestedObject("delete_line", "Deletes a single line")
                .AddProperty("line_number", "number", "Line number to delete, line_number must be greater than '0'.")
            .EndNestedObject()
            .AddNestedObject("insert_before", "Inserts code before a specified line of existing code")
                .AddProperty("line_number", "number", "Line number before which to insert new code, line_number must be greater than '0'.")
                .AddProperty("new_data", "string", "Code to insert before the specified line.")
            .EndNestedObject()
            .AddNestedObject("insert_between", "Inserts code between two lines of existing code")
                .AddProperty("start_line", "number", "Starting line number for the insertion range, start_line must be greater than '0'.")
                .AddProperty("end_line", "number", "Ending line number for the insertion range.")
                .AddProperty("new_data", "string", "Code to insert between the specified lines.")
            .EndNestedObject()
            .AddNestedObject("insert_after", "Inserts code after a specified line of existing code")
                .AddProperty("line_number", "number", "Line number after which to insert new code, line_number must be greater than '0'.")
                .AddProperty("new_data", "string", "Code to insert after the specified line.")
            .EndNestedObject()
            .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(codeModificationTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(codeModificationTool));
        _toolPermissions.RegisterTool(toolName: "edit_code", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 31 edit_code

        #region 32 create_venv

        var createNewVenv = new ToolTransformerBuilder()
             .AddToolName("create_venv")
             .AddDescription("Establishes isolated Python execution environments. This tool creates dedicated virtual environments with specified Python versions and configurations, ensuring dependency isolation and consistent execution contexts.")
             .AddConstraint("Use only when environment-specific issues require isolation",
                            "Requires explicit user approval before creating new environments")
             .AddKeyWords("Environment Management", "Dependency Isolation", "Python Configuration")
             .AddInstructionHeader("Virtual Environment Guidelines")
             .AddInstructions("Create environments only when necessary for dependency management")
             .AddInstructions("Specify the appropriate Python version for project compatibility")
             .AddNestedObject(
                 objectName: "create_venv",
                 objectDescription: "Environment configuration parameters that control the creation and setup of a Python virtual environment. Defines the isolation characteristics for package management.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "editor_id",
                 fieldType: "string",
                 fieldDescription: "Optional identifier of an Editor instance to focus after environment creation. Provides workflow continuity during the setup process."
             )
             .AddProperty(
                 fieldName: "version",
                 fieldType: "string",
                 fieldDescription: "Target Python interpreter version for the virtual environment. Supports versions '3.8', '3.9', '3.10', or '3.11', with '3.9' as the default if unspecified.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "venv_name",
                 fieldType: "string",
                 fieldDescription: "Custom name identifier for the virtual environment directory. Standard convention is 'venv' unless project-specific naming is required."
             )
             .AddProperty(
                 fieldName: "overwrite",
                 fieldType: "boolean",
                 fieldDescription: "Control flag that determines whether an existing environment with the same name should be replaced. When true, removes any existing environment before creation."
             )
             .AddProperty(
                 fieldName: "tool_use_log",
                 fieldType: "string",
                 fieldDescription: "Technical record of the environment creation process capturing version, configuration, and outcome details for system logging."
             )
             .AddProperty(
                 fieldName: "chat_message",
                 fieldType: "string",
                 fieldDescription: "User-facing notification explaining the environment creation status and any follow-up actions required for proper configuration."
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(createNewVenv);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(createNewVenv));
        _toolPermissions.RegisterTool(toolName: "create_venv", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
"compile_code",
"edit_code",
"install_pip_packages",
"list_editors",
"list_files",
"manage_files",
"memory_tool",
"open_file",
"run_command_script",
"script_pwr",
"save_file",
"screen_capture",
});

        #endregion 32 create_venv

        #region 33 install_pip_packages

        var installPipTool = new ToolTransformerBuilder()
             .AddToolName("install_pip_packages")
             .AddDescription("Manages external dependencies by installing Python packages into virtual environments. This tool resolves package requirements, handles version compatibility, and prepares the runtime environment for application execution.")
             .AddConstraint("Requires active virtual environment before installation",
                            "Package version conflicts may require resolution")
             .AddKeyWords("Dependency Management", "Package Installation", "Environment Configuration")
             .AddInstructionHeader("Package Installation Guidelines")
             .AddInstructions("Specify exact version requirements when necessary for compatibility")
             .AddInstructions("Group related packages in single installation commands where possible")
             .AddInstructions("Verify installation success before proceeding with code execution")
             .AddNestedObject(
                 objectName: "python_tool_object",
                 objectDescription: "Package installation configuration that specifies dependencies and target environment. Controls the package resolution and installation process.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "pip_commands",
                 fieldType: "array",
                 fieldDescription: "Collection of pip installation directives formatted as comments (e.g., '# pip install package_name==1.0.0'). Each entry represents a distinct installation operation.",
                 items: new Dictionary<string, string> { { "type", "string" } }
             )
             .AddProperty(
                 fieldName: "version",
                 fieldType: "string",
                 fieldDescription: "Python interpreter version to target for package compatibility. Supported versions include '3.8', '3.9', '3.10', and '3.11', with '3.9' as the default.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "tool_use_log",
                 fieldType: "string",
                 fieldDescription: "Technical record of the installation process capturing package details, version information, and outcome status for system logging."
             )
             .AddProperty(
                 fieldName: "chat_message",
                 fieldType: "string",
                 fieldDescription: "User-facing notification explaining the installation results, highlighting any successful installations or issues encountered."
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(installPipTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(installPipTool));
        _toolPermissions.RegisterTool(toolName: "install_pip_packages", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
"compile_code",
"close_editor",
"create_editors",
"edit_code",
"file_exists",
"focus_editor",
"generate_python_code",
"get_full_content",
"install_pip_packages",
"list_editors",
"list_files",
"list_saved_projects",
"load_project",
"memory_tool",
"open_file",
"read_file",
"run_command_script",
"save_file",
"screen_capture",
"script_pwr"
});

        #endregion 33 install_pip_packages

        #region 34 compile_code

        var compileCode = new ToolTransformerBuilder()
                .AddToolName("compile_code")
                .AddDescription("Validates Python code through syntax checking and compilation. This tool performs pre-execution validation to identify errors and potential issues before runtime, ensuring code quality and execution readiness.")
                .AddConstraint("Requires file structure verification before checking",
                               "User approval needed before compilation process")
                .AddKeyWords("Code Validation", "Syntax Checking", "Error Detection")
                .AddInstructionHeader("Code Checking Guidelines")
                .AddInstructions("Verify all imports and dependencies are properly installed")
                .AddInstructions("Ensure file paths and references are correctly configured")
                .AddInstructions("Review validation results before proceeding to execution")
                .AddNestedObject(
                    objectName: "python_tool_object",
                    objectDescription: "Validation configuration parameters specifying the target code and environment. Controls the syntax checking and compilation process for error detection.",
                    isRequired: true
                )
                .AddProperty(
                    fieldName: "editor_id",
                    fieldType: "string",
                    fieldDescription: "Unique identifier of the Editor instance containing the Python code to validate. Must reference an existing Editor containing code.",
                    isRequired: true
                )
                .AddProperty(
                    fieldName: "version",
                    fieldType: "string",
                    fieldDescription: "Target Python interpreter version for syntax validation. Supported options include '3.8', '3.9', '3.10', and '3.11', with '3.9' as the default.",
                    isRequired: true
                )
                .EndNestedObject()
                .EndObject()
                .Build();

        toolList.Add(compileCode);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(compileCode));
        _toolPermissions.RegisterTool(toolName: "compile_code", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 34 compile_code

        #region 35 run_code

        var executeCode = new ToolTransformerBuilder()
            .AddToolName("run_code")
            .AddDescription("Executes Python code in a controlled environment. This tool runs validated code files within the appropriate Python interpreter, capturing output and execution results for analysis and presentation.")
            .AddConstraint("Requires successful compilation before execution",
                           "User approval mandatory before running any code")
            .AddKeyWords("Code Execution", "Runtime Environment", "Output Capture")
            .AddInstructionHeader("Code Execution Guidelines")
            .AddInstructions("Verify successful compilation before requesting execution")
            .AddInstructions("Ensure all dependencies are properly installed")
            .AddInstructions("Document expected outputs and potential runtime behaviors")
            .AddNestedObject(
                objectName: "python_tool_object",
                objectDescription: "Execution configuration defining the target file and runtime environment. Controls how and where the Python code is executed and how results are captured.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "version",
                fieldType: "string",
                fieldDescription: "Python interpreter version to use for execution. Supported versions include '3.8', '3.9', '3.10', and '3.11', with '3.9' as the default if unspecified.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "file_name",
                fieldType: "string",
                fieldDescription: "Base name of the Python file to execute, including extension. Typically 'main.py' for application entry points.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "file_path",
                fieldType: "string",
                fieldDescription: "Complete path to the target Python file, including directory structure and filename. Must reference a validated file with correct syntax.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(executeCode);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(executeCode));
        _toolPermissions.RegisterTool(toolName: "run_code", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 35 run_code

        #region 36 list_files

        var getFilesAndFolders = new ToolTransformerBuilder()
             .AddToolName("list_files")
             .AddDescription("Inventories file system content in the project workspace. This tool examines directory structures, identifies available files, and creates a comprehensive map of the project's file organization for navigation and verification.")
             .AddConstraint("Large directory structures may impact performance",
                            "Default listing is restricted to the current project scope")
             .AddKeyWords("File System", "Directory Structure", "Project Organization")
             .AddInstructionHeader("File Listing Guidelines")
             .AddInstructions("Examine the file structure before code execution or file operations")
             .AddInstructions("Verify critical files exist in expected locations")
             .AddInstructions("Use listings to detect potential file naming conflicts")
             .AddNestedObject(
                 objectName: "list_files",
                 objectDescription: "Directory scanning parameters that control which project files are inventoried. Configures the scope and context of the file system examination.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "version",
                 fieldType: "string",
                 fieldDescription: "Python environment context for file listing operations. Determines which project workspace is examined based on Python version ('3.8', '3.9', '3.10', or '3.11')."
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(getFilesAndFolders);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getFilesAndFolders));
        _toolPermissions.RegisterTool(toolName: "list_files", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 36 list_files

        #region 37 read_file

        var readFileTool = new ToolTransformerBuilder()
             .AddToolName("read_file")
             .AddDescription("Retrieves and displays file content from the file system. This tool accesses existing files and presents their contents for inspection, analysis, and reference without loading them into an Editor environment.")
             .AddConstraint("Target file must exist in the specified location",
                            "Large files may impact performance and display")
             .AddKeyWords("Content Retrieval", "File Inspection", "Data Access")
             .AddInstructionHeader("File Reading Guidelines")
             .AddInstructions("Verify file existence before attempting to read")
             .AddInstructions("Use for quick content inspection without editing needs")
             .AddInstructions("Consider performance impact when reading very large files")
             .AddNestedObject(
                 objectName: "file_class",
                 objectDescription: "File access parameters that specify the target content to retrieve. Controls which file is read and how its contents are presented.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "file_path",
                 fieldType: "string",
                 fieldDescription: "Full path to the target file, including directory structure and filename. Must reference an existing accessible file in the project workspace.",
                 isRequired: true
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(readFileTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(readFileTool));
        _toolPermissions.RegisterTool(toolName: "read_file", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 37 read_file

        #region 38 manage_files

        var fileSystemTool = new ToolTransformerBuilder()
             .AddToolName("manage_files")
             .AddDescription("Performs comprehensive file system operations across the project workspace. This tool handles file creation, modification, organization, and maintenance tasks through a flexible command structure supporting diverse file management needs.")
             .AddConstraint("Operations affecting existing files require verification",
                            "Destructive operations cannot be automatically undone")
             .AddKeyWords("File Management", "Directory Organization", "Content Manipulation")
             .AddInstructionHeader("File System Operation Guidelines")
             .AddInstructions("Verify paths and file existence before operations")
             .AddInstructions("Group related operations for efficient execution")
             .AddInstructions("Document changes to maintain clear project structure")
             .AddNestedObject(
                objectName: "filesystem_commands",
                objectDescription: "Collection of file system operations to be executed sequentially. Each command represents a specific file or directory action with appropriate parameters.",
                isArray: true
                )
                .AddNestedObject("feedback_response", "Contains result feedback for file system operations")
                    .AddProperty("tool_use_log", "string", "Log message describing the result of the operation for feedback purposes.")
                    .AddProperty("chat_message", "string", "Brief message to display in the chat regarding the operation outcome.")
                .EndNestedObject()
                .AddNestedObject("append_text", "Appends text to an existing file")
                    .AddProperty("file_path", "string", "Path to the target file.")
                    .AddProperty("content", "string", "Text content to append to the file.")
                .EndNestedObject()
                .AddNestedObject("write_text", "Writes text to a file, overwriting existing content")
                    .AddProperty("file_path", "string", "Path to the target file.")
                    .AddProperty("content", "string", "Text content to write to the file.")
                .EndNestedObject()
                .AddNestedObject("read_text", "Reads text from a file")
                    .AddProperty("file_path", "string", "Path to the file to be read.")
                .EndNestedObject()
                .AddNestedObject("create_folder", "Creates a new folder")
                    .AddProperty("folder_path", "string", "Directory path where the new folder will be created.")
                .EndNestedObject()
                .AddNestedObject("delete_file", "Deletes a specified file")
                    .AddProperty("file_path", "string", "Path to the file to delete.")
                .EndNestedObject()
                .AddNestedObject("delete_folder", "Deletes a specified folder")
                    .AddProperty("folder_path", "string", "Path of the folder to delete.")
                .EndNestedObject()
                .AddNestedObject("copy_folder", "Copies a folder to a new location")
                    .AddProperty("source_path", "string", "Path to the source folder.")
                    .AddProperty("destination_path", "string", "Target path where the folder should be copied.")
                .EndNestedObject()
                .AddNestedObject("move_folder", "Moves a folder to a new location")
                    .AddProperty("source_path", "string", "Path to the source folder.")
                    .AddProperty("destination_path", "string", "Target path where the folder should be moved.")
                .EndNestedObject()
                .AddNestedObject("rename_file", "Renames a file")
                    .AddProperty("file_path", "string", "Current path of the file.")
                    .AddProperty("new_name", "string", "New name for the file.")
                .EndNestedObject()
                .AddNestedObject("compress_file", "Compresses a file into a zip archive")
                    .AddProperty("file_path", "string", "Path to the file to compress.")
                    .AddProperty("zip_path", "string", "Destination path for the zip file.")
                .EndNestedObject()
                .AddNestedObject("compress_folder", "Compresses a folder into a zip archive")
                    .AddProperty("folder_path", "string", "Path to the folder to compress.")
                    .AddProperty("zip_path", "string", "Destination path for the zip file.")
                .EndNestedObject()
                .AddNestedObject("check_file_exists", "Checks if a specified file exists")
                    .AddProperty("file_path", "string", "Path of the file to check.")
                .EndNestedObject()
                .AddNestedObject("check_folder_exists", "Checks if a specified folder exists")
                    .AddProperty("folder_path", "string", "Path of the folder to check.")
                .EndNestedObject()
                .AddNestedObject("get_file_properties", "Retrieves properties of a file")
                    .AddProperty("file_path", "string", "Path to the file.")
                .EndNestedObject()
                .AddNestedObject("list_files", "Lists all files in a specified folder")
                    .AddProperty("folder_path", "string", "Path to the folder.")
                .EndNestedObject()
                .AddNestedObject("list_subfolders", "Lists all subfolders within a specified folder")
                    .AddProperty("folder_path", "string", "Path to the folder.")
                .EndNestedObject()
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(fileSystemTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(fileSystemTool));
        _toolPermissions.RegisterTool(toolName: "manage_files", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
"compile_code",
"close_editor",
"create_app_plan",
"create_editors",
"create_venv",
"edit_code",
"file_exists",
"focus_editor",
"generate_python_code",
"get_full_content",
"install_pip_packages",
"list_editors",
"list_files",
"list_saved_projects",
"load_project",
"manage_files",
"memory_tool",
"open_file",
"read_file",
"run_command_script",
"save_file",
"save_project",
"screen_capture",
"script_pwr"
});

        #endregion 38 manage_files

        #region 39 memory_tool

        var memoryTool = new ToolTransformerBuilder()
          .AddToolName("memory_tool")
          .AddDescription("Manages persistent information storage across development sessions. This tool enables saving and retrieving important context, decisions, and reference data throughout the development lifecycle, preserving critical information between operations.")
          .AddConstraint("Memory modifications require direct user authorization",
                         "Storage capacity is limited for efficiency")
          .AddKeyWords("Persistent Storage", "Context Preservation", "Information Management")
          .AddInstructionHeader("Memory Management Guidelines")
          .AddInstructions("Store critical configuration details and decisions")
          .AddInstructions("Retrieve stored context when resuming prior work")
          .AddInstructions("Use structured formats for complex information")
          .AddNestedObject(
              objectName: "memory_tool",
              objectDescription: "Memory operation parameters that control storage and retrieval of persistent information. Manages the system's knowledge preservation mechanisms.",
              isRequired: true
          )
          .AddProperty(
              fieldName: "add_memory",
              fieldType: "string",
              fieldDescription: "Information to be stored in persistent memory for future reference. Content will be preserved across sessions and available for later retrieval."
          )
          .AddProperty(
              fieldName: "get_memories",
              fieldType: "string",
              fieldDescription: "Request directive to retrieve previously stored information. When provided, returns all accessible memory entries from the current context."
          )
          .EndNestedObject()
          .EndObject()
          .Build();

        toolList.Add(memoryTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(memoryTool));
        _toolPermissions.RegisterTool(toolName: "memory_tool", canInitiateToolChain: false, allowedTools: allToolsAllowed);

        #endregion 39 memory_tool

        #region 40 get_full_content

        var getFullContent = new ToolTransformerBuilder()
             .AddToolName("get_full_content")
             .AddDescription("Retrieves complete message content that was previously truncated. This tool accesses the original, unabridged version of long messages that were automatically shortened during communication, enabling access to the full context and details.")
             .AddConstraint("Message ID must reference an existing truncated message",
                            "Very large content may still require paginated review")
             .AddKeyWords("Content Retrieval", "Message Restoration", "Context Recovery")
             .AddInstructionHeader("Content Retrieval Guidelines")
             .AddInstructions("Use only when critical information was truncated")
             .AddInstructions("Verify the correct message ID before retrieval")
             .AddNestedObject(
                 objectName: "get_full_content",
                 objectDescription: "Message retrieval parameters that identify the specific truncated content to recover. Controls which communication is restored to its complete form.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "message_id",
                 fieldType: "string",
                 fieldDescription: "System identifier for the truncated message to be retrieved in full. Must reference a valid message that contains additional content beyond what was initially displayed."
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(getFullContent);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getFullContent));
        _toolPermissions.RegisterTool(toolName: "get_full_content", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 40 get_full_content

        //  screencapture:

        #region 41 screen_capture

        var getScreenCapture = new ToolTransformerBuilder()
.AddToolName("screen_capture")
.AddDescription("Creates visual documentation of the current system state. This tool captures screenshots of the development environment for verification, troubleshooting, and documentation purposes, providing visual context for complex situations.")
.AddConstraint("Captures are limited to visible application windows",
               "Use selectively to avoid unnecessary visual noise")
.AddKeyWords("Visual Documentation", "Environment Snapshot", "Troubleshooting Aid")
.AddInstructionHeader("Screen Capture Guidelines")
.AddInstructions("Capture key states for documentation purposes")
.AddInstructions("Provide clear context for what the capture demonstrates")
.AddInstructions("Use captures to document errors or unexpected behaviors")
.AddNestedObject(
    objectName: "screen_capture",
    objectDescription: "Capture operation parameters specifying what to document and how to present the result. Controls the visual documentation process.",
    isRequired: true
    )
    .AddProperty(
        fieldName: "request_capture",
        fieldType: "string",
        fieldDescription: "Specific description of what should be captured and why. Provides context for what the image is intended to document or demonstrate."
    )
    .AddProperty(
        fieldName: "tool_use_log",
        fieldType: "string",
        fieldDescription: "Technical documentation of the capture purpose for system logging. Explains the rationale and context for creating this visual record."
    )
    .AddProperty(
        fieldName: "chat_message",
        fieldType: "string",
        fieldDescription: "User-facing explanation of the captured content and its significance. Helps interpret what the visual documentation represents."
    )
.EndNestedObject()
.EndObject()
.Build();

        toolList.Add(getScreenCapture);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(getScreenCapture));
        _toolPermissions.RegisterTool(toolName: "screen_capture", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 41 screen_capture

        //      goto theend;

        #region 42 script_pwr

        var scriptPwrScript = new ToolTransformerBuilder()
             .AddToolName("script_pwr")
             .AddDescription("Executes PowerShell scripts within the development environment. This tool runs administrative and system management commands through PowerShell, enabling advanced automation and environment configuration capabilities.")
             .AddConstraint("Requires appropriate system permissions",
                            "Scripts run with current user security context")
             .AddKeyWords("PowerShell Automation", "System Administration", "Script Execution")
             .AddInstructionHeader("PowerShell Execution Guidelines")
             .AddInstructions("Use proper error handling in PowerShell scripts")
             .AddInstructions("Validate user permissions before executing system commands")
             .AddInstructions("Capture and process command output appropriately")
             .AddNestedObject(
                 objectName: "script_pwr",
                 objectDescription: "PowerShell execution parameters containing the script to run and optional configuration. Controls advanced system automation capabilities.",
                 isRequired: true
             )
             .AddProperty(
                 fieldName: "script",
                 fieldType: "string",
                 fieldDescription: "PowerShell script content to be executed in the system environment. Contains commands, logic, and automation directives for system management.",
                 isRequired: true
             )
             .EndNestedObject()
             .EndObject()
             .Build();

        toolList.Add(scriptPwrScript);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(scriptPwrScript));
        _toolPermissions.RegisterTool(toolName: "script_pwr", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 42 script_pwr

        #region 43 run_command_script

        var scriptCmdScript = new ToolTransformerBuilder()
            .AddToolName("run_command_script")
            .AddDescription("Executes command-line scripts in the system shell. This tool runs sequences of commands in the native command processor, supporting system operations, environment setup, and core utilities that require direct shell access.")
            .AddConstraint("Commands execute with current user privileges",
                           "Environment variables persist only for the duration of execution")
            .AddKeyWords("Command Automation", "Shell Execution", "System Operations")
            .AddInstructionHeader("Command Script Guidelines")
            .AddInstructions("Include proper error checking and exit codes")
            .AddInstructions("Use platform-appropriate commands for compatibility")
            .AddInstructions("Document expected command behavior and output")
            .AddNestedObject(
                objectName: "command_script",
                objectDescription: "Script execution parameters containing the commands to run in the system shell. Controls direct interaction with the operating system command processor.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "script",
                fieldType: "string",
                fieldDescription: "Command sequence to be executed by the system shell. Contains individual commands, parameters, and control flow for system operations.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(scriptCmdScript);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(scriptCmdScript));
        _toolPermissions.RegisterTool(toolName: "run_command_script", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
"compile_code",
"close_editor",
"create_app_plan",
"create_editors",
"create_venv",
"edit_code",
"file_exists",
"focus_editor",
"generate_python_code",
"get_full_content",
"install_pip_packages",
"list_editors",
"list_files",
"list_saved_projects",
"load_project",
"manage_files",
"memory_tool",
"open_file",
"read_file",
"run_code",
"run_command_script",
"save_file",
"save_project",
"screen_capture",
"script_pwr"
            });

        #endregion 43 run_command_script

        #region 44 file_exists

        var fileExistsTool = new ToolTransformerBuilder()
            .AddToolName("file_exists")
            .AddDescription("Verifies the existence of specified files in the file system. This tool checks whether a target file is present at a given location, enabling conditional logic and validation before file operations.")
            .AddConstraint("Checks only file existence, not content or permissions",
                           "Path must be fully qualified for accurate results")
            .AddKeyWords("File Verification", "Path Validation", "Resource Checking")
            .AddInstructionHeader("Existence Checking Guidelines")
            .AddInstructions("Verify critical dependencies before operations")
            .AddInstructions("Use accurate, fully-qualified paths for reliability")
            .AddInstructions("Implement appropriate handling for both existence states")
            .AddNestedObject(
                objectName: "file_class",
                objectDescription: "File verification parameters specifying the target location to check. Controls which file path is evaluated for existence.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "file_path",
                fieldType: "string",
                fieldDescription: "Complete path to the file being verified, including directory structure and filename. The tool will check whether this exact path exists in the file system.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(fileExistsTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(fileExistsTool));
        _toolPermissions.RegisterTool(toolName: "file_exists", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 44 file_exists

        #region 45 save_project

        var saveAndLoadProjectTool = new ToolTransformerBuilder()
            .AddToolName("save_project")
            .AddDescription("Preserves the complete state of the current development project. This tool creates a persistent snapshot of all project components, configurations, and files, enabling later restoration and continued development.")
            .AddConstraint("Overwrites existing projects with the same name",
                           "Large projects may require significant storage space")
            .AddKeyWords("Project Persistence", "State Preservation", "Development Continuity")
            .AddInstructionHeader("Project Saving Guidelines")
            .AddInstructions("Use descriptive project names for easy identification")
            .AddInstructions("Save at logical completion points in development")
            .AddInstructions("Document the project state and progress in the name or notes")
            .AddNestedObject(
                objectName: "editor_config",
                objectDescription: "Project saving parameters that control how the current development state is preserved. Defines the identification and storage of the project snapshot.",
                isRequired: true
                )
                .AddProperty(
                    fieldName: "project_name",
                    fieldType: "string",
                    fieldDescription: "Unique identifier for the saved project state. Provides a reference name for future loading and distinguishes between multiple saved versions.",
                    isRequired: true
                    )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(saveAndLoadProjectTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(saveAndLoadProjectTool));
        _toolPermissions.RegisterTool(toolName: "save_project", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 45 save_project

        #region 46 list_saved_projects

        var listSavedProjectsTool = new ToolTransformerBuilder()
            .AddToolName("list_saved_projects")
            .AddDescription("Retrieves information about previously saved development projects. This tool inventories available project snapshots along with their metadata, enabling informed selection for project restoration.")
            .AddConstraint("Results limited by count parameter for performance",
                           "Only shows projects accessible to the current user")
            .AddKeyWords("Project Discovery", "Saved State Listing", "Development History")
            .AddInstructionHeader("Project Listing Guidelines")
            .AddInstructions("Review available projects before loading operations")
            .AddInstructions("Use metadata to identify the appropriate project version")
            .AddInstructions("Verify project compatibility with current requirements")
            .AddNestedObject(
                objectName: "project_list",
                objectDescription: "Listing parameters that control how many saved projects are retrieved and displayed. Configures the project discovery operation.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "count",
                fieldType: "integer",
                fieldDescription: "Maximum number of project entries to retrieve. Default: '100'",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(listSavedProjectsTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(listSavedProjectsTool));
        _toolPermissions.RegisterTool(toolName: "list_saved_projects", canInitiateToolChain: false, allowedTools: FullAccess ? allToolsAllowed : new[] {
"compile_code",
"close_editor",
"create_app_plan",
"create_editors",
"edit_code",
"file_exists",
"focus_editor",
"generate_python_code",
"get_full_content",
"list_editors",
"list_files",
"list_saved_projects",
"load_project",
"memory_tool",
"save_project"
});

        #endregion 46 list_saved_projects

        #region 47 load_project

        var LoadProjectTool = new ToolTransformerBuilder()
            .AddToolName("load_project")
            .AddDescription("Restores a previously saved development project state. This tool loads a complete project snapshot including all files, configurations, and Editor states, enabling continued development from a saved checkpoint.")
            .AddConstraint("Overwrites any unsaved changes in the current workspace",
                           "Project must exist and be accessible to the current user")
            .AddKeyWords("State Restoration", "Project Recovery", "Development Continuation")
            .AddInstructionHeader("Project Loading Guidelines")
            .AddInstructions("Save any active work before loading a different project")
            .AddInstructions("Verify the correct project name before loading")
            .AddInstructions("Confirm successful loading before continuing development")
            .AddNestedObject(
                objectName: "editor_config",
                objectDescription: "Project loading parameters that identify which saved state to restore. Controls which development snapshot is activated in the current workspace.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "project_name",
                fieldType: "string",
                fieldDescription: "Unique identifier of the saved project to restore. Must match an existing project name exactly to retrieve the correct development state.",
                isRequired: true
            )
            .EndNestedObject()
            .EndObject()
            .Build();

        toolList.Add(LoadProjectTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(LoadProjectTool));
        _toolPermissions.RegisterTool(toolName: "load_project", canInitiateToolChain: false, allowedTools: FullAccess ? allToolsAllowed : new[] {
"compile_code",
"close_editor",
"create_editors",
"edit_code",
"file_exists",
"focus_editor",
"generate_python_code",
"get_full_content",
"install_pip_packages",
"list_editors",
"list_files",
"list_saved_projects",
"load_project",
"manage_files",
"memory_tool",
"open_file",
"read_file",
"save_file",
"screen_capture"
});

        #endregion 47 load_project

        #region 48 Research

        var researchTool = new ToolTransformerBuilder()
        .AddToolName("research")
        .AddDescription("Performs web research on a specified topic and synthesizes the findings. This tool searches the web for information, processes multiple sources, and returns a comprehensive summary.")
        .AddConstraint("Requires internet connectivity",
                       "Synthesis quality depends on available sources")
        .AddKeyWords("Web Research", "Information Gathering", "Knowledge Synthesis")
        .AddInstructionHeader("Research Guidelines")
        .AddInstructions("Provide clear, specific search queries for best results")
        .AddInstructions("Allow sufficient time for comprehensive research")
        .AddInstructions("Consider the credibility of sources when reviewing results")
        .AddNestedObject(
            objectName: "research_tool",
            objectDescription: "Research parameters that control the search query and result processing. Defines what information to search for and how to process the results.",
            isRequired: true
        )
        .AddProperty(
            fieldName: "search_query",
            fieldType: "string",
            fieldDescription: "The search query to use for researching information. This scrapes the web for data, so use keywords rather than overly specific queries.",
            isRequired: true
        )
        //.AddProperty(
        //    fieldName: "how_many",
        //    fieldType: "integer",
        //    fieldDescription: "Number of sources to pull data from '1' to '20' and is set to '10' by default"
        //)
        .AddProperty(
            fieldName: "user_request",
            fieldType: "string",
            fieldDescription: "A description of the user's request or question to provide context for the research, allowing the AI to aggregate the correct data.",
            isRequired: true
        )
        .AddProperty(
            fieldName: "reasoning_effort",
            fieldType: "string",
            fieldDescription: "Level of detail for the synthesis: 'low', 'medium', or 'high'. Default: 'medium'.",
            isRequired: true
        )
        .EndNestedObject()
        .EndObject()
        .Build();

        toolList.Add(researchTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(researchTool));
        _toolPermissions.RegisterTool(toolName: "research", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new[] {
            "compile_code",
            "memory_tool",
            "research",
            "screen_capture"
        });

        #endregion 48 Research

        #region 49 Search

        var webSearchTool = new ToolTransformerBuilder()
        .AddToolName("web_search_server")
        .AddDescription("Performs web search.")
        .AddConstraint("Requires internet connectivity", "Synthesis quality depends on available sources")
        .AddKeyWords("Web Search", "Information Gathering")
        .AddInstructionHeader("Research Guidelines")
        .AddInstructions("Provide clear, specific search queries for best results")
        .AddInstructions("Consider the credibility of sources when reviewing results")

        .AddNestedObject(
            objectName: "web_search_server",
            objectDescription: "tool name.",
            isRequired: true
        )

        .AddProperty(
            fieldName: "name",
            fieldType: "string",
            fieldDescription: "web_search",
            isRequired: true
        )

        .AddProperty(
            fieldName: "type",
            fieldType: "string",
            fieldDescription: "web_search_20250305",
            isRequired: true
        )

        .AddProperty(
            fieldName: "max_uses",
            fieldType: "string",
            fieldDescription: "number of results.",
            isRequired: true
        )

        .AddProperty(
            fieldName: "actual_search_query",
            fieldType: "string",
            fieldDescription: "The actual search query.",
            isRequired: true
        )

        .AddProperty(
            fieldName: "allowed_domains",
            fieldType: "string",
            fieldDescription: "List of domains to restrict the search to. This is a comma-separated list of domains.",
            isRequired: false
        )

        .AddProperty(
            fieldName: "blocked_domains",
            fieldType: "string",
            fieldDescription: "List of domains to block from the search. This is a comma-separated list of domains.",
            isRequired: false
        )

        .AddNestedObject(
            objectName: "user_location",
            objectDescription: "When regional data is required.",
            isRequired: false
            )

            .AddProperty(
                fieldName: "type",
                fieldType: "string",
                fieldDescription: "approximate",
                isRequired: false
            )

            .AddProperty(
                fieldName: "city",
                fieldType: "string",
                fieldDescription: "San Francisco",
                isRequired: false
            )

            .AddProperty(
                fieldName: "region",
                fieldType: "string",
                fieldDescription: "California",
                isRequired: false
            )

            .AddProperty(
                fieldName: "country",
                fieldType: "string",
                fieldDescription: "US",
                isRequired: false
            )

            .AddProperty(
                fieldName: "timezone",
                fieldType: "string",
                fieldDescription: "America/Los_Angeles",
                isRequired: false
            )

            .EndNestedObject()

        .EndNestedObject()

        .EndObject()
        .Build();

        toolList.Add(webSearchTool);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(webSearchTool));
        _toolPermissions.RegisterTool(toolName: "web_search_server", canInitiateToolChain: true, allowedTools: FullAccess ? allToolsAllowed : new string[] { });

        #endregion 49 Search

        #region 50 request_agent_creation (Revised for Capabilities)

        var requestAgentCreationTool = new ToolTransformerBuilder()
            .AddToolName("request_agent_creation")
            .AddDescription("Requests the creation of a new specialized cognitive agent. Specify the agent's name, purpose, the complete prompt text, and a list of relevant capabilities. Requires user confirmation. Returns a success or failure message.")
            // --- Constraints ---
            .AddConstraint("Requires explicit user approval via the UI before the agent is created.")
            .AddConstraint("The 'prompt_text' MUST be a complete, well-structured prompt following the established format.")
            .AddConstraint("Ensure the specified 'agent_name' is descriptive and likely unique.")
            .AddConstraint("Provide a list of relevant 'capabilities' for the agent.") // New Constraint
                                                                                       // --- Keywords ---
            .AddKeyWords("Create Agent", "New Agent", "Agent Specification", "Add Capability", "Instantiate Agent", "Agent Capabilities") // Added keyword
                                                                                                                                          // --- Instructions ---
            .AddInstructionHeader("Agent Creation Request Guidelines")
            .AddInstructions("Provide the exact 'agent_name' and 'agent_purpose'.")
            .AddInstructions("Provide the complete, formatted 'prompt_text' generated for the new agent.")
            .AddInstructions("Provide a list of relevant 'capabilities' (e.g., 'Code Generation', 'Critical Analysis', 'Long-term Planning').") // New Instruction
            .AddInstructions("User approval is required before the agent is added to the system.")
            // --- Input Object ---
            .AddNestedObject(
                objectName: "agent_creation_request",
                objectDescription: "Parameters specifying the new cognitive agent, including its prompt and capabilities.", // Updated Description
                isRequired: true
            )
            // --- Properties within the input object ---
            .AddProperty(
                fieldName: "agent_name",
                fieldType: "string",
                fieldDescription: "A concise, descriptive, and unique name for the new agent.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "agent_purpose",
                fieldType: "string",
                fieldDescription: "A one-sentence description of the agent's primary goal.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "prompt_text",
                fieldType: "string",
                fieldDescription: "The complete, structured prompt text generated for the new agent.",
                isRequired: true
            )
            // --- NEW CAPABILITIES PROPERTY ---
            .AddProperty(
                fieldName: "capabilities",
                fieldType: "array", // Array type
                fieldDescription: "A list of strings describing the key capabilities or skills this agent should possess (e.g., ['Code Generation', 'Python Proficiency', 'API Design']).",
                isRequired: true, // Make it required for better definition
                items: new Dictionary<string, string> { { "type", "string" } } // Specify items are strings
            )
            // --- END NEW CAPABILITIES PROPERTY ---
            .EndNestedObject() // End of agent_creation_request object
            .EndObject() // End of main tool object
            .Build();

        toolList.Add(requestAgentCreationTool);
        if (outputPreview) toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(requestAgentCreationTool));

        // --- Permissions (Keep as is or adjust if needed) ---
        _toolPermissions.RegisterTool(
            toolName: "request_agent_creation",
            canInitiateToolChain: true, allToolsAllowed);

        #endregion 50 request_agent_creation (Revised for Capabilities)

        #region 51 request_verification (Updated)

        var requestVerificationTool = new ToolTransformerBuilder()
            .AddToolName("request_verification")
            // --- Updated Description ---
            .AddDescription("Requests a review of provided output (e.g., code, plan, text) from a specified cognitive perspective (e.g., Sentinel, Evaluator, Chief). Use this to get feedback, validation, or analysis before proceeding. Returns the reviewer's feedback.")
            // --- Constraints ---
            .AddConstraint("This tool invokes another AI perspective and may take time.")
            .AddConstraint("Provide the complete output to be reviewed in 'output_to_review'.")
            .AddConstraint("MUST specify the target 'reviewer_perspective' (e.g., 'Sentinel', 'Evaluator', 'Chief').")
            // --- Keywords ---
            .AddKeyWords("Verification", "Review Request", "Feedback Request", "Compliance Check", "Quality Review", "Analysis Request", "Second Opinion")
            // --- Instructions ---
            .AddInstructionHeader("Verification Request Guidelines")
            .AddInstructions("Clearly state the output needing review in 'output_to_review'.")
            .AddInstructions("Specify the reviewing perspective in 'reviewer_perspective'.")
            .AddInstructions("Optionally provide 'specific_concerns' for the reviewer to focus on (e.g., 'Check for security flaws', 'Evaluate feasibility').")
            // --- Input Object ---
            .AddNestedObject(
                objectName: "verification_request",
                objectDescription: "Parameters for requesting a review from a specific cognitive perspective.",
                isRequired: true // The entire request object is required
            )
            // --- Properties within the input object ---
            .AddProperty(
                fieldName: "reviewer_perspective", // **** THE NEW REQUIRED FIELD ****
                fieldType: "string",
                fieldDescription: "The exact name of the AI perspective agent to perform the review (e.g., 'Sentinel', 'Evaluator', 'Chief', 'Innovator', 'Strategist', 'Navigator').",
                isRequired: true // *** Mark as required ***
            )
            .AddProperty(
                fieldName: "output_to_review",
                fieldType: "string",
                fieldDescription: "The complete text content (e.g., code, plan, analysis, document segment) that needs to be reviewed by the specified perspective.",
                isRequired: true
            )
            .AddProperty(
                fieldName: "specific_concerns",
                fieldType: "string",
                fieldDescription: "(Optional) Specific instructions, context, rules, or areas the reviewer should focus on during their analysis (e.g., 'Check against security checklist X', 'Evaluate alignment with initial user request', 'Assess potential performance bottlenecks').",
                isRequired: false // Optional field
            )
            .EndNestedObject() // End of verification_request object
            .EndObject() // End of main tool object (needed by ToolTransformerBuilder)
            .Build();

        toolList.Add(requestVerificationTool);
        if (outputPreview) toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(requestVerificationTool));

        // --- Permissions ---
        // Allow most agents to request verification from others.
        // The invoked reviewer (e.g., Sentinel) might need basic tools like memory or content retrieval.
        _toolPermissions.RegisterTool(
            toolName: "request_verification",
            canInitiateToolChain: true,
            allowedTools: allToolsAllowed // Tools the *reviewer* might need
        );

        #endregion 51 request_verification (Updated)

        //    theend:

        #region 52 Identify Elements

        var identifyElements = new ToolTransformerBuilder()
            .AddToolName("identify_elements")
            .AddDescription("Identifies UI elements based on user-provided descriptions or coordinates.")

            // .AddKeyWords("identify", "ui", "element", "screen", "coordinates")

            .AddInstructionHeader("Follow these instructions to control the mouse and keyboard:")
            .AddInstructions("1. Operations are executed in the order they appear in the array.")
            .AddInstructions("2. Each description should include the elements general location within the image, its color, shape and any identifying text or features that might be associated with it..")

            .AddNestedObject(objectName: "ui_elements", objectDescription: "An array of UI element descriptions.", isRequired: true, isArray: true)
               .AddProperty(fieldName: "index", fieldType: "integer", fieldDescription: "Only needed when multiple UI elements are identified.", isRequired: false)
                .AddProperty(fieldName: "element_description", fieldType: "string", fieldDescription: "A description of a UI element to identify.", isRequired: true)
            .EndNestedObject()

            .EndObject()
            .Build();

        toolList.Add(identifyElements);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(identifyElements));
        _toolPermissions.RegisterTool(toolName: "identify_elements", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 52 Identify Elements

        #region 53 Confirm Elements

        var confirmElements = new ToolTransformerBuilder()
            .AddToolName("confirm_elements")
           .AddDescription("Confirm UI element Identification before clicking.")

            // .AddKeyWords("identify", "ui", "element", "screen", "coordinates")

            //  .AddInstructionHeader("Follow these instructions to control the mouse and keyboard:")
            // .AddInstructions("1. Operations are executed in the order they appear in the array.")

            //  .AddInstructions("2. Each Description should include the elements general location within the image, its color, shape and any identifying text or features that might be associated with it..")

            .AddNestedObject(objectName: "ui_elements", objectDescription: "The screen coordinates of the element to click. The click will be at the center of this box.", isRequired: true, isArray: true)

                .AddProperty(fieldName: "element_description", fieldType: "string", fieldDescription: "Brief description of the element being confirmed", isRequired: true)

                .AddNestedObject(objectName: "bounding_box", objectDescription: "The screen coordinates of the element to click. The click will be at the center of this box.", isRequired: true)
                    .AddProperty(fieldName: "x", fieldType: "integer", fieldDescription: "The x-coordinate of the top-left corner.", isRequired: true)
                    .AddProperty(fieldName: "y", fieldType: "integer", fieldDescription: "The y-coordinate of the top-left corner.", isRequired: true)
                    .AddProperty(fieldName: "width", fieldType: "integer", fieldDescription: "The width of the bounding box.", isRequired: true)
                    .AddProperty(fieldName: "height", fieldType: "integer", fieldDescription: "The height of the bounding box.", isRequired: true)
                    .EndNestedObject()
                .EndNestedObject()

            .EndObject()

            .Build();

        toolList.Add(confirmElements);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(confirmElements));
        _toolPermissions.RegisterTool(toolName: "confirm_elements", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 53 Confirm Elements

        #region 54 Mouse and Keyboard Emulator Tool

        var mouseAndKeyboard = new ToolTransformerBuilder()
            .AddToolName("keyboard_and_mouse")
            .AddDescription("Automates user input by emulating mouse clicks and keyboard typing. Can perform a sequence of operations.")

            // --- Completed Descriptive Fields ---
            .AddConstraint("For mouse clicks, the user MUST provide screen coordinates or a clear description of the UI element to click.", "Requires bounding_box for clicks.")
            .AddKeyWords("type", "click", "mouse", "keyboard", "input", "automate", "fill form", "press key")

            .AddInstructionHeader("Follow these instructions to control the mouse and keyboard:")
            .AddInstructions("1. Operations are executed in the order they appear in the array.")
            .AddInstructions(@"2. For keyboard input, use the `type_with_keyboard` object. You are to follow a specific syntax for generating keyboard and text input commands. The syntax consists of two parts: literal text and special commands.

### 1. Syntax Rules

* **Literal Text**: Any character not inside square brackets is treated as literal text to be typed.
* **Special Commands**: All non-character keys, key combinations, and pauses are enclosed in square brackets `[]`. These commands are **case-insensitive**.
* **Key Combinations**: To represent pressing multiple keys at once (e.g., for shortcuts), separate the key names with a comma inside the brackets. Example: `[CTRL,C]` for ""Copy"".
* **Pauses**: To add a delay between actions, use the command `[PAUSE,duration]`, where `duration` is the time to wait in milliseconds. Example: `[PAUSE,1000]` creates a 1-second pause.

### 2. Examples

**Open Notepad and type a message**: `[WINDOWS,R]notepad[ENTER][PAUSE,500]This is a sample text.[ENTER]`
**Select all text, copy it, and paste it twice**: `[CTRL,A][CTRL,C][PAUSE,250][CTRL,V][PAUSE,250][CTRL,V]`
**Use the ""Save As"" menu to save a file**: `[ALT,F][A]MyFileName.txt[ENTER]`
**Navigate to a website in a browser**: `https://www.google.com[ENTER]`

### 3. Supported Special Keys

You may use any of the following key names inside the brackets:

* **Modifiers**: `SHIFT`, `CTRL`, `ALT`, `WINDOWS`
* **Navigation**: `UP`, `DOWN`, `LEFT`, `RIGHT`, `HOME`, `END`, `PGUP`, `PGDN`
* **Function**: `F1` through `F16`
* **Action Keys**: `ENTER`, `TAB`, `ESC`, `INSERT`, `DELETE` (or `DEL`), `BACKSPACE` (or `BS`)
* **Lock Keys**: `CAPSLOCK`, `NUMLOCK`, `SCROLLLOCK`
* **Other**: `BREAK`, `HELP`, `ADD`, `SUBTRACT`, `MULTIPLY`, `DIVIDE`")

            .AddInstructions("3. For mouse clicks, use the `ui_elements` object, providing the `bounding_box` for the target.")
            .AddInstructions("4. Use the `pause` property in milliseconds (e.g., 1000 for 1 second) to wait AFTER an operation completes.")

            .AddNestedObject(objectName: "ui_type_and_click", objectDescription: "An array of mouse and keyboard operations.", isRequired: true, isArray: true)

                .AddProperty(fieldName: "index", fieldType: "integer", fieldDescription: "The index of the drag operation, starting from zero. (Only needed for multi-drag operations)")

                .AddNestedObject(objectName: "input_type", objectDescription: "Describes the type of input to emulate.", isRequired: true)
                    .AddProperty(fieldName: "type", fieldType: "string", fieldDescription: "Select what will be used: 'keyboard', 'mouse', or 'both'.", isRequired: true)
                .EndNestedObject()

                .AddNestedObject(objectName: "type_with_keyboard", objectDescription: "Keyboard typing operation.")
                    .AddProperty(fieldName: "text", fieldType: "string", fieldDescription: "Text to be typed. Can include special commands like '[ENTER]' or '[CTRL,V]'.", isRequired: true)
                    .AddProperty(fieldName: "pause", fieldType: "integer", fieldDescription: "Pause duration in milliseconds after this typing operation. Default: 0.")
                .EndNestedObject()

                .AddNestedObject(objectName: "ui_elements", objectDescription: "Mouse click operation.")
                    .AddProperty(fieldName: "index", fieldType: "integer", fieldDescription: "The index of the click operation, starting from zero. (Only needed for multi-click operations)")
                    .AddProperty(fieldName: "pause", fieldType: "integer", fieldDescription: "Pause duration in milliseconds after this click operation. Default: 0.")
                    .AddProperty(fieldName: "double_click", fieldType: "boolean", fieldDescription: "Set to true to perform a double-click instead of a single click. Default: false.")

                    .AddNestedObject(objectName: "bounding_box", objectDescription: "The screen coordinates of the element to click. The click will be at the center of this box.", isRequired: true)
                        .AddProperty(fieldName: "x", fieldType: "integer", fieldDescription: "The x-coordinate of the top-left corner.", isRequired: true)
                        .AddProperty(fieldName: "y", fieldType: "integer", fieldDescription: "The y-coordinate of the top-left corner.", isRequired: true)
                        .AddProperty(fieldName: "width", fieldType: "integer", fieldDescription: "The width of the bounding box.", isRequired: true)
                        .AddProperty(fieldName: "height", fieldType: "integer", fieldDescription: "The height of the bounding box.", isRequired: true)
                    .EndNestedObject()
                .EndNestedObject()

                .AddNestedObject(objectName: "drag_and_drop", objectDescription: "Source and destination parameters for a drag-and-drop operation.")
                    .AddProperty(fieldName: "pause", fieldType: "integer", fieldDescription: "Pause duration in milliseconds after this drag and drop operation. Default: 0.")

                    .AddNestedObject(objectName: "source_box", objectDescription: "The bounding box of the element to start dragging from.", isRequired: true)
                        .AddProperty(fieldName: "x", fieldType: "integer", fieldDescription: "The x-coordinate of the source's top-left corner.", isRequired: true)
                        .AddProperty(fieldName: "y", fieldType: "integer", fieldDescription: "The y-coordinate of the source's top-left corner.", isRequired: true)
                        .AddProperty(fieldName: "width", fieldType: "integer", fieldDescription: "The width of the source element.", isRequired: true)
                        .AddProperty(fieldName: "height", fieldType: "integer", fieldDescription: "The height of the source element.", isRequired: true)
                    .EndNestedObject()

                    .AddNestedObject(objectName: "destination_box", objectDescription: "The bounding box of the element to drop onto.", isRequired: true)
                        .AddProperty(fieldName: "x", fieldType: "integer", fieldDescription: "The x-coordinate of the destination's top-left corner.", isRequired: true)
                        .AddProperty(fieldName: "y", fieldType: "integer", fieldDescription: "The y-coordinate of the destination's top-left corner.", isRequired: true)
                        .AddProperty(fieldName: "width", fieldType: "integer", fieldDescription: "The width of the destination element.", isRequired: true)
                        .AddProperty(fieldName: "height", fieldType: "integer", fieldDescription: "The height of the destination element.", isRequired: true)
                    .EndNestedObject()
                .EndNestedObject()

            .EndNestedObject()
            .EndObject() // This seems to be a custom method in your builder
            .Build();

        toolList.Add(mouseAndKeyboard);
        toolListPreview.AppendLine(ToolStringOutput.GenerateToolJson(mouseAndKeyboard));

        _toolPermissions.RegisterTool(toolName: "keyboard_and_mouse", canInitiateToolChain: true, allowedTools: allToolsAllowed);

        #endregion 54 Mouse and Keyboard Emulator Tool

        if (outputPreview)
        {
            Debug.WriteLine(toolListPreview.ToString());
            foreach (var toolPermission in _toolPermissions._toolPermissions)
            {
                Debug.WriteLine($"Registered tool: {toolPermission.Key}");
                Debug.WriteLine($"  Can initiate: {toolPermission.Value.CanInitiateToolChain}");
                Debug.WriteLine($"  Allowed tools: {string.Join(", ", toolPermission.Value.AllowedTools)}");
            }
        }
        return toolList;
    }
}
