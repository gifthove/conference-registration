import React from "react";
import PropTypes from "prop-types";
import RegistrationFormStepOne from "./RegistrationFormStepOne";

const RegistrationForm = ({
  registration,
  onSave,
  onChange,
  saving = false,
  errors = {},
  step,
  onNextClick,
  onBackClick,
  sessions
}) => {
  return (
    <form onSubmit={onSave}>
      <br />
      <p className="offset-md-1">
        Please {registration.id ? "edit" : "book for"} your conference by ing
        the form below, specify the expected number joining the conference.
      </p>
      <br />
      {errors.onSave && (
        <div className="alert alert-danger" role="alert">
          {errors.onSave}
        </div>
      )}
      {step === 0 ? (
        <RegistrationFormStepOne
          registration={registration}
          onChange={onChange}
          errors={errors}
          onNextClick={onNextClick}
          sessions={sessions}
        />
      ) : (
        <div>
          <hr />
          <h1>Terms and Conditions ("Terms")</h1>

          <p>Last updated: May 27, 2019</p>

          <p>
            Please read these Terms and Conditions ("Terms", "Terms and
            Conditions") carefully before using the
            https://https://bullyingprevention.help/.help/ website (the
            "Service") operated by Bullying prevention ("us", "we", or "our").
          </p>

          <p>
            Your access to and use of the Service is conditioned on your
            acceptance of and compliance with these Terms. These Terms apply to
            all visitors, users and others who access or use the Service.
          </p>

          <p>
            By accessing or using the Service you agree to be bound by these
            Terms. If you disagree with any part of the terms then you may not
            access the Service. The Terms and Conditions agreement for Bullying
            prevention has been created with the help of{" "}
            <a href="https://www.termsfeed.com/">TermsFeed</a>.
          </p>

          <h2>Links To Other Web Sites</h2>

          <p>
            Our Service may contain links to third-party web sites or services
            that are not owned or controlled by Bullying prevention.
          </p>

          <p>
            Bullying prevention has no control over, and assumes no
            responsibility for, the content, privacy policies, or practices of
            any third party web sites or services. You further acknowledge and
            agree that Bullying prevention shall not be responsible or liable,
            directly or indirectly, for any damage or loss caused or alleged to
            be caused by or in connection with use of or reliance on any such
            content, goods or services available on or through any such web
            sites or services.
          </p>

          <p>
            We strongly advise you to read the terms and conditions and privacy
            policies of any third-party web sites or services that you visit.
          </p>

          <h2>Governing Law</h2>

          <p>
            These Terms shall be governed and construed in accordance with the
            laws of New Zealand, without regard to its conflict of law
            provisions.
          </p>

          <p>
            Our failure to enforce any right or provision of these Terms will
            not be considered a waiver of those rights. If any provision of
            these Terms is held to be invalid or unenforceable by a court, the
            remaining provisions of these Terms will remain in effect. These
            Terms constitute the entire agreement between us regarding our
            Service, and supersede and replace any prior agreements we might
            have between us regarding the Service.
          </p>

          <h2>Changes</h2>

          <p>
            We reserve the right, at our sole discretion, to modify or replace
            these Terms at any time. If a revision is material we will try to
            provide at least 15 days notice prior to any new terms taking
            effect. What constitutes a material change will be determined at our
            sole discretion.
          </p>

          <p>
            By continuing to access or use our Service after those revisions
            become effective, you agree to be bound by the revised terms. If you
            do not agree to the new terms, please stop using the Service.
          </p>

          <h2>Contact Us</h2>

          <p>If you have any questions about these Terms, please contact us.</p>

          <div className="form-check">
            <input
              type="checkbox"
              className="form-check-input"
              id="exampleCheck1"
            />
            <label className="form-check-label" labeleFor="exampleCheck1">
              I accept the terms and use
            </label>
          </div>
          <div className="offset-md-4">
            <button
              type="button"
              className="btn btn-secondary"
              onClick={onBackClick}
            >
              Back
            </button>
            <button type="submit" disabled={saving} className="btn btn-primary">
              {saving ? "Submitting..." : "Submit"}
            </button>
          </div>
        </div>
      )}
    </form>
  );
};

RegistrationForm.propTypes = {
  registration: PropTypes.object.isRequired,
  errors: PropTypes.object,
  onSave: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  saving: PropTypes.bool,
  step: PropTypes.number,
  onNextClick: PropTypes.func.isRequired,
  onBackClick: PropTypes.func.isRequired,
  sessions: PropTypes.array.isRequired
};

export default RegistrationForm;
