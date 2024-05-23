import './Modal.css'; 

const Modal = ({ isOpen, onClose, isCreate }) => {
    if (!isOpen) {
        return null;
    }

    return (
        <div className="modal-overlay" onClick={onClose}>
            <div className="modal-content" onClick={e => e.stopPropagation()}>
                <h2>Success!</h2>
                {isCreate === true && <p>You have successfully posted your Advertisement!</p>}
                {isCreate === false && <p>You have successfully modified your Advertisement!</p>}
                <button onClick={onClose}>Close</button>
            </div>
        </div>
    );
};

export default Modal;