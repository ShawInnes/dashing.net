// Generated by CoffeeScript 1.7.1
(function() {
  console.log("Yeah! The dashboard has started!");

  Dashing.on('ready', function() {
    var contentWidth, timeout;
    Dashing.widget_margins || (Dashing.widget_margins = [5, 5]);
    Dashing.widget_base_dimensions || (Dashing.widget_base_dimensions = [300, 360]);
    Dashing.numColumns || (Dashing.numColumns = 4);
    timeout = null;
    $(document).on("mousemove", function() {
      if (timeout !== null) {
        $("body").css({
          cursor: ""
        });
        $(".gs_w").css({
          cursor: ""
        });
        clearTimeout(timeout);
      }
      return timeout = setTimeout(function() {
        timeout = null;
        $("body").css({
          cursor: "none"
        });
        return $(".gs_w").css({
          cursor: "none"
        });
      }, 5000);
    });
    contentWidth = (Dashing.widget_base_dimensions[0] + Dashing.widget_margins[0] * 2) * Dashing.numColumns;
    return Batman.setImmediate(function() {
      $('.gridster').width(contentWidth);
      return $('.gridster ul:first').gridster({
        widget_margins: Dashing.widget_margins,
        widget_base_dimensions: Dashing.widget_base_dimensions,
        avoid_overlapped_widgets: !Dashing.customGridsterLayout,
        draggable: {
          stop: Dashing.showGridsterInstructions,
          start: function() {
            return Dashing.currentWidgetPositions = Dashing.getWidgetPositions();
          }
        }
      });
    });
  });

}).call(this);

//# sourceMappingURL=application.map
