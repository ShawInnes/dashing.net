// Generated by CoffeeScript 1.7.1
(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  Dashing.Meter = (function(_super) {
    __extends(Meter, _super);

    Meter.accessor('value', Dashing.AnimatedValue);

    function Meter() {
      Meter.__super__.constructor.apply(this, arguments);
      this.observe('value', function(value) {
        return $(this.node).find(".meter").val(value).trigger('change');
      });
    }

    Meter.prototype.ready = function() {
      var meter;
      meter = $(this.node).find(".meter");
      meter.attr("data-bgcolor", meter.css("background-color"));
      meter.attr("data-fgcolor", meter.css("color"));
      return meter.knob();
    };

    return Meter;

  })(Dashing.Widget);

}).call(this);

//# sourceMappingURL=meter.map
